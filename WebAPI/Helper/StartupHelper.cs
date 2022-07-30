using BusinessLogic.Base;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Base;
using DataAccess.EntityFramework;
using DataAccess.EntityFramework.Repositories;
using DataAccess.TempData;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Helper
{
    public static class StartupHelper
    {
        public static void DI(this IServiceCollection services)
        {
            services.AddDbContext<TrendkurduDbContext>();
            services.AddScoped<IProductService, ProductService>();
            //services.AddSingleton<IProductRepo, ProductData>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<ICategoryService, CategoryService>();
            //services.AddSingleton<ICategoryRepo, CategoryData>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ISellerService, SellerService>();
            //services.AddSingleton<ISellerRepo, SellerData>();
            services.AddScoped<ISellerRepo, SellerRepo>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
