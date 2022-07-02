using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using Serilog.Events;
using WebAPI.Logs;

namespace WebAPI.Middlewares
{
    public enum RequestLogLevel
    {
        None = 0,
        OnlyErrors = 1,
        Everything = 2
    }

    public static class RequestLoggerMiddlewareHelper
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app, RequestLogLevel level, ILogger logger, IWatchLog hesapkurduWatch)
        {
            return app.UseMiddleware<SerilogMiddleware>(level, logger, hesapkurduWatch);
        }
    }

    public class SerilogMiddleware
    {
        private const string MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";

        private static ILogger Log;
        private readonly RequestLogLevel _level;
        private readonly IWatchLog _hesapkurduWatch;
        private readonly RequestDelegate _next;

        public SerilogMiddleware(RequestDelegate next, RequestLogLevel level, ILogger logger, IWatchLog hesapkurduWatch)
        {
            Log = logger ?? throw new NullReferenceException(nameof(ILogger));
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _level = level;
            _hesapkurduWatch = hesapkurduWatch;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));
            _hesapkurduWatch.Restart();
            try
            {
                await _next(httpContext);
                _hesapkurduWatch.Stop();
                switch (_level)
                {
                    case RequestLogLevel.OnlyErrors:
                        {
                            var statusCode = httpContext.Response?.StatusCode;
                            if (statusCode > 399)
                            {
                                var log = LogForErrorContext(httpContext);
                                log.Write(LogEventLevel.Error, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, statusCode, _hesapkurduWatch.ElapsedMilliseconds);
                            }
                        }
                        break;
                    case RequestLogLevel.Everything:
                        {
                            var statusCode = httpContext.Response?.StatusCode;
                            var level = statusCode > 399 ? LogEventLevel.Error : LogEventLevel.Information;

                            var log = level == LogEventLevel.Error ? LogForErrorContext(httpContext) : Log;

                            log.Write(level, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, statusCode, _hesapkurduWatch.ElapsedMilliseconds);
                        }
                        break;
                }
            }
            // Never caught, because `LogException()` returns false.
            catch (Exception ex) when (LogException(httpContext, ex) && _level != RequestLogLevel.None)
            {
            }
            finally
            {
                if (_hesapkurduWatch.IsRunning) _hesapkurduWatch.Stop();
            }
        }

        private bool LogException(HttpContext httpContext, Exception ex)
        {
            if (_hesapkurduWatch.IsRunning)
            {
                _hesapkurduWatch.Stop();
            }

            LogForErrorContext(httpContext)
                .Error(ex, MessageTemplate, httpContext.Request.Method, httpContext.Request.Path, (int)HttpStatusCode.InternalServerError, _hesapkurduWatch.ElapsedMilliseconds);

            return false;
        }

        private static ILogger LogForErrorContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            var result = Log
                .ForContext("RequestHeaders", request.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()), true)
                .ForContext("RequestHost", request.Host)
                .ForContext("RequestProtocol", request.Protocol);

            if (request.HasFormContentType)
                result = result.ForContext("RequestForm",
                    request.Form.ToDictionary(v => v.Key, v => v.Value.ToString()));
            if (httpContext.Request.QueryString.HasValue)
                result = result.ForContext("QueryString", request.QueryString.Value);

            if (request.Body.CanRead && request.Method != HttpMethod.Get.Method)
            {
                var body = request.Body;
                request.EnableBuffering();
                if (body.CanSeek)
                {
                    body.Seek(0, SeekOrigin.Begin);
                }
                var bodyAsText = new StreamReader(body).ReadToEndAsync();
                result = result.ForContext("RequestBody", bodyAsText);
            }

            return result;
        }
    }
}
