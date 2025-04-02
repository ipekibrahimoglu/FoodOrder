using System.Linq.Expressions;
using Core.Entities;


namespace Core.DataAccess
{
    public interface IGenericRepository<T> where T: class, IEntity, new()
        // class : sadece classlari parametre gecebiliriz. int, string vs gecilemez
        // IEntity : IEntity'nin kendisi ya da onun alt classlari parametre gecilebilir.
        // new() : IEntity gibi interfacelerin de parametre gecmesi engellenir. Sadece newlene bilen yapilar yani classlar parametre gecilebilir.
    {
        //interface metotlari default publictir, interface'in kendisi default internaldir.
        //factory methods
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
