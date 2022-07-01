using BusinessLogic.Base;
using BusinessLogic.Services;
using DataAccess.Base;
using DataAccess.TempData;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Helper
{
    public static class StartupHelper
    {
        public static void DI(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IProductData, ProductData>();
            services.AddSingleton<ICategoryService, CategoryService>();
            services.AddSingleton<ICategoryData, CategoryData>();
            services.AddSingleton<ISellerService, SellerService>();
            services.AddSingleton<ISellerData, SellerData>();
        }
    }
}
