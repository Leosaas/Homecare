using AutoMapper;
using EnterpriseService.Application.MessageService.Consumers;
using EnterpriseService.Application.MessageService.Publisher;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EnterpriseService.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<AddEnterpriseConsumer>();
                cfg.UsingRabbitMq((context, config) =>
                {
                    config.Host(configuration["RabbitMQ:HostName"],"/", host =>
                    {
                        host.Username(configuration["RabbitMQ:UserName"]);
                        host.Password(configuration["RabbitMQ:Password"]);
                    });
                    config.ReceiveEndpoint(configuration["RabbitMQ:Queue:AddEnterprise"]!, c =>
                    {
                        c.ConfigureConsumer<AddEnterpriseConsumer>(context);
                    });
                });
            });
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IEnterprisePublisher, EnterprisePublisher>();
            return services;
        }
    }
}
