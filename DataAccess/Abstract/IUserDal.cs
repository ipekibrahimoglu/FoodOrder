using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserDal : IGenericRepository<User>
{
    Task<User> GetByEmailAsync(string email);
}