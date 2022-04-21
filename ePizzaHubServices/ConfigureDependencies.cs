using Microsoft.Extensions.DependencyInjection;
using System;
using ePizzaHubRepositories;
using Microsoft.EntityFrameworkCore;
using ePizzaHubEntities;
using ePizzaHubRepositories.Interfaces;
using ePizzaHubRepositories.Implementations;
using ePizzaHubServices.Interfaces;
using ePizzaHubServices.Implementations;
using Microsoft.Extensions.Configuration;

namespace ePizzaHubServices
{
    public static class ConfigureDependencies
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //Database
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
            });

            services.AddScoped<DbContext, AppDbContext>();

            //Repositories
            //Generic repository
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Item>, Repository<Item>>();
            services.AddScoped<IRepository<ItemType>, Repository<ItemType>>();
            services.AddScoped<IRepository<Cart>, Repository<Cart>>();
            services.AddScoped<IRepository<CartItem>, Repository<CartItem>>();
            //specific repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICartRepository, CartRepository>();


            //Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<ICartService, CartService>();



        }
    }
}
