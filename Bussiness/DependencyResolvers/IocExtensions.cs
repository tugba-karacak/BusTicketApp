using Bussiness.Concrete;
using Bussiness.Interfaces;
using Data.Concrete.EntityFrameworkCore;
using Data.Concrete.EntityFrameworkCore.Context;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.DependencyResolvers
{
    public static class IocExtensions
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BusContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });


            services.AddScoped(typeof(IGenericDal<>), typeof(GenericDalEf<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IApplicationUserService, ApplicationUserManager>();
            services.AddScoped<IVoyageService, VoyageManager>();
            services.AddScoped<ITicketService, TicketManager>();

         
        }
    }
}
