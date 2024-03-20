using EnterpriseService.Application.Commands;
using EnterpriseService.Application.Reponses;
using EnterpriseService.Core.Entities;
using EnterpriseService.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.Handlers
{
    public class DeleteEnterpriseCommandHandler : IRequestHandler<DeleteEnterpriseCommand, ServiceResponse>
    {
        private readonly IEnterpriseRepository enterpriseRepository;

        public DeleteEnterpriseCommandHandler(IEnterpriseRepository enterpriseRepository)
        {
            this.enterpriseRepository = enterpriseRepository;
        }
        public async Task<ServiceResponse> Handle(DeleteEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var result = await enterpriseRepository.Delete(request.Id);
            string message = result ? "Deleted" : "Fail to delete";
            return new ServiceResponse(result, message);
        }
    }
}
