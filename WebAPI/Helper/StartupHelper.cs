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
            services.AddSingleton<IProductService, ProductService>();
            //services.AddSingleton<IProductRepo, ProductData>();
            services.AddSingleton<IProductRepo, ProductRepo>();
            services.AddSingleton<ICategoryService, CategoryService>();
            //services.AddSingleton<ICategoryRepo, CategoryData>();
            services.AddSingleton<ICategoryRepo, CategoryRepo>();
            services.AddSingleton<ISellerService, SellerService>();
            //services.AddSingleton<ISellerRepo, SellerData>();
            services.AddSingleton<ISellerRepo, SellerRepo>();
            services.AddSingleton(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
