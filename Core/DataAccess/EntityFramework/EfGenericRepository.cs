using System.Linq.Expressions;
using Core.DataAccess;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfGenericRepository<T, C> : IGenericRepository<T>
        where T : class, IEntity, new()
        where C : DbContext, new()

    {
    public async Task AddAsync(T entity)
    {
        using var context = new C();
        await context.Set<T>().AddAsync(entity);
        await context.SaveChangesAsync();

    }

    public async Task DeleteAsync(Guid id)
    {
        using var context = new C();
        var entityToDelete = await context.Set<T>().FindAsync(id);
        if (entityToDelete != null)
        {
            context.Set<T>().Remove(entityToDelete);
            await context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        using var context = new C();
        return await context.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate)
    {
        using var context = new C();
        return await context.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        using var context = new C();
        return await context.Set<T>().FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        using var context = new C();
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }
    }
}
