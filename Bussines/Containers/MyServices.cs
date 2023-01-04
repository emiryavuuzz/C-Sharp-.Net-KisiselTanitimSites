using Business.Abstract;
using Business.Concrete;
using Business.FluentValidations;
using Bussines.Abstract;
using Bussines.Concrete;
using DataAccess.Concrete;
using DataAccess.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Containers
{
    public static class MyServices
    {
        public static IServiceCollection MyServiceInstance(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>();
            services.AddScoped<IServislerService, ServislerService>();
            services.AddScoped<ISertifikalarService, SertifikalarService>();
            services.AddScoped<IYeteneklerService, YeteneklerService>();
            services.AddScoped<IProjelerService, ProjelerService>();
            services.AddScoped<IDahaOnceCalistigiYerlerService, DahaOnceCalistigiYerlerService>();
            services.AddScoped<IEgitimService, EgitimService>();
            services.AddScoped<IUserService, UserService>();

    
            services.AddSingleton<IValidator<Users>, ValidationUsers>();



            return services;

        }
    }
}
