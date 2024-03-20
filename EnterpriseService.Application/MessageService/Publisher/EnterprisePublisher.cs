using EnterpriseService.Application.Interface;
using EnterpriseService.Core.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.MessageService.Publisher
{
    public interface IEnterprisePublisher : IPublisher<Enterprise> { }
    public class EnterprisePublisher : Publisher<Enterprise>, IEnterprisePublisher
    {
        public EnterprisePublisher(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
