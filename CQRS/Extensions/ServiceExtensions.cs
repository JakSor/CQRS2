using Domain;
using Repository;
using Repository.Interfaces;

namespace CQRS.Extensions
{
    public static class ServiceExtensions
    {
        //Klasse om ConfigureServices proper te houden
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
            public static void ConfigureCustomDependencyInjection(this IServiceCollection services)
            {
                //services.AddScoped<ILogger>();


                ////services.AddScoped<IConfiguration>(Configuration);
                //services.AddSingleton<ILoggerManager, LoggerManager>();
                services.AddScoped<IProductRepository, ProductRepository>();
                services.AddScoped<IBaseRepository<ShoppingBasket>, BaseRepository<ShoppingBasket>>();
                services.AddScoped<IBaseRepository<ShoppingBasketItem>, BaseRepository<ShoppingBasketItem>>();
            }
        
       
    }
}
