using EnterpriseService.Application.Interface;
using EnterpriseService.Core.Entities;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.MessageService.Consumers
{
    public class AddEnterpriseConsumer : IConsumer<Enterprise>
    {
        public async Task Consume(ConsumeContext<Enterprise> context)
        {
            var msg = context.Message;
            await Console.Out.WriteLineAsync(msg.ToString());
        }
    }
}
