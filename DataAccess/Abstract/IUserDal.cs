using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract;

public interface IUserDal : IGenericRepository<User>
{
    Task<UserDto> GetByEmailAsync(string email);
}