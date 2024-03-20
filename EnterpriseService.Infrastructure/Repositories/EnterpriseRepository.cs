using AutoMapper;
using EnterpriseService.Core.Entities;
using EnterpriseService.Core.Repositories;
using EnterpriseService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Infrastructure.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly IMapper mapper;
        private readonly AppDbContext appDbContext;

        public EnterpriseRepository(IMapper mapper, AppDbContext appDbContext)
        {
            this.mapper = mapper;
            this.appDbContext = appDbContext;
        }
        private async Task SaveChangesAsync()
        {
            await appDbContext.SaveChangesAsync();
        }
        public async Task<bool> Add(Enterprise entity)
        {
            var enterprise = mapper.Map<Entities.Enterprise>(entity);
            appDbContext.Enterprises.Add(enterprise);
            await SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(long id)
        {
            var enterprise = appDbContext.Enterprises.Find(id);
            if(enterprise == null)
            {
                return false;
            }
            appDbContext.Enterprises.Remove(enterprise);
            await SaveChangesAsync();
            return true;
        }

        public async Task<Enterprise> Get(long id)
        {
            var enterprise = await appDbContext.Enterprises.FindAsync(id);
            if (enterprise == null)
            {
                return null!;
            }
            return mapper.Map<Enterprise>(enterprise); 
        }

        public async Task<List<Enterprise>> GetAll()
        {
            return mapper.Map<List<Enterprise>>(await appDbContext.Enterprises.AsNoTracking().ToListAsync());
        }

        public async Task<bool> Update(Enterprise entity)
        {
            var enterprise = mapper.Map<Entities.Enterprise>(entity);
            appDbContext.Enterprises.Update(enterprise);
            await SaveChangesAsync();
            return true;
        }
    }
}
