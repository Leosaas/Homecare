using EnterpriseService.Application.Commands;
using EnterpriseService.Application.Reponses;
using EnterpriseService.Core.Entities;
using EnterpriseService.Core.Repositories;
using MediatR;
using MassTransit;
namespace EnterpriseService.Application.Handlers
{
    public class AddEnterpriseCommandHandler : IRequestHandler<AddEnterpriseCommand, ServiceResponse>
    {
        private readonly IEnterpriseRepository enterpriseRepository;
        private readonly IPublishEndpoint publishEndpoint;

        public AddEnterpriseCommandHandler(IEnterpriseRepository enterpriseRepository, IPublishEndpoint publishEndpoint)
        {
            this.enterpriseRepository = enterpriseRepository;
            this.publishEndpoint = publishEndpoint;
        }
        public async Task<ServiceResponse> Handle(AddEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var enterprise = new Enterprise
            {
                Id = request.Id
            };
            var result = await enterpriseRepository.Add(enterprise);
            if (!result)
                return new ServiceResponse(result, "Fail to add");
            //var isPublishSuccess = enterprisePublisher.SendMessageToQueue(QueueConstants.AddEnterpriseQueue, enterprise);
            //string message = isPublishSuccess ? "Added" : "Error occur when publish to queue"; 
            await publishEndpoint.Publish<Enterprise>(enterprise);
            return new ServiceResponse(true, "Added");
        }
    }
}
