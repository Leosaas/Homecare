using AutoMapper;
using EnterpriseService.Core.Repositories;
using EnterpriseService.Infrastructure.Context;
using EnterpriseService.Infrastructure.Mapper;
using EnterpriseService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EnterpriseDB")));
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping());
            }).CreateMapper());
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            return services;
        }
    }
}
