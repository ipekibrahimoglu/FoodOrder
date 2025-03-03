using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class, IEntity, new()
    {
        public async Task AddAsync(T entity)
        {
            using var context = new SouthwindContext();
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();

        }

        public async Task DeleteAsync(Guid id)
        {
            using var context = new SouthwindContext();
            var entityToDelete = await context.Set<T>().FindAsync(id);
            if (entityToDelete != null)
            {
                context.Set<T>().Remove(entityToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var context = new SouthwindContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            using var context = new SouthwindContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new SouthwindContext();
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
