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
    public class EditEnterpriseCommandHandler : IRequestHandler<EditEnterpriseCommand, ServiceResponse>
    {
        private readonly IEnterpriseRepository enterpriseRepository;

        public EditEnterpriseCommandHandler(IEnterpriseRepository enterpriseRepository)
        {
            this.enterpriseRepository = enterpriseRepository;
        }
        public async Task<ServiceResponse> Handle(EditEnterpriseCommand request, CancellationToken cancellationToken)
        {
            var enterprise = new Enterprise
            {
                Id = request.Id
            };
            var result = await enterpriseRepository.Update(enterprise);
            string message = result ? "Updated" : "Fail to update";
            return new ServiceResponse(result, message);
        }
    }
}
