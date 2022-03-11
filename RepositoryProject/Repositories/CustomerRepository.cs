using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepositoryProject.Data;
using RepositoryProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryProject.Repositories
{
    public class CustomerRepository : GenericRepository<Cutomer>, ICutomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<Cutomer>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(CustomerRepository));
                return new List<Cutomer>();
            }
        }

        public override async Task<bool> Upsert(Cutomer entity)
        {
            try
            {
                var existingCutomer = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingCutomer == null)
                    return await Add(entity);

                existingCutomer.FirstName = entity.FirstName;
                existingCutomer.LastName = entity.LastName;
                existingCutomer.Email = entity.Email;
                existingCutomer.Phone = entity.Phone;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(CustomerRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(CustomerRepository));
                return false;
            }
        }
    }
}
