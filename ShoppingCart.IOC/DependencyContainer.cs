using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AutoMapper;
using ShoppingCart.Application.AutoMapper;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, string connectionString )
        {
            services.AddDbContext<ShoppingCartDbContext>(options =>
              options.UseSqlServer(connectionString));

            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductsService, ProductsService>();

            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<ICategoriesService, CategoriesService>();


            services.AddScoped<IMembersRepository, MembersRepository>();
            services.AddScoped<IMembersService, MembersService>();

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            //adds the automapper to the services collection
            AutoMapperConfiguration.RegisterMappings();
            //register the profiles (e.g. DomainToViewProfile)
            //         with any instances of the automapper that will be initialized

        }
    }
}
