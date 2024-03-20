using EnterpriseService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Core.Repositories
{
    public interface IEnterpriseRepository
    {
        Task<Enterprise> Get(long id);
        Task<List<Enterprise>> GetAll();
        Task<bool> Delete(long id);
        Task<bool> Update(Enterprise entity);
        Task<bool> Add(Enterprise entity);
    }
}
