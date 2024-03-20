using EnterpriseService.Application.Reponses;
using EnterpriseService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.Interface
{
    public interface IAddressServices
    {
        Task<Enterprise> GetEnterprise(long id);
        Task<IReadOnlyList<Enterprise>> GetEnterprises();
        Task<EnterpriseResponse> Delete(long id);
        Task<EnterpriseResponse> Update(Enterprise entity);
        Task<EnterpriseResponse> Add(Enterprise entity);
    }
}
