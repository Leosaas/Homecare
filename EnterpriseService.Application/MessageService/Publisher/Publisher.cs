using EnterpriseService.Application.Interface;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace EnterpriseService.Application.MessageService.Publisher
{
    public class Publisher<T> : IPublisher<T> where T : class
    {
        private readonly IConfiguration configuration;

        public Publisher(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool SendMessageToQueue(string queueName,T message)
        {
            if (string.IsNullOrEmpty(queueName))
                return false;
            //var factory = new ConnectionFactory() { HostName = "192.168.1.8", Port=5672, UserName = "guest", Password="guest"};
            var factory = new ConnectionFactory() { HostName = configuration["RabbitMQ:HostName"], 
                Port = int.Parse(configuration["RabbitMQ:Port"]!), 
                UserName = configuration["RabbitMQ:UserName"], 
                Password = configuration["RabbitMQ:Password"] };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queueName, true, false, false, null);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: queueName, body: body);
            return true;
        }
    }
}
