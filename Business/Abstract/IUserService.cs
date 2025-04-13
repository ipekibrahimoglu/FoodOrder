using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<User>> GetByIdAsync(Guid id);
        Task<IDataResult<IEnumerable<UserDto>>> GetAllAsync();
        Task<IDataResult<IEnumerable<User>>> GetByConditionAsync(Expression<Func<User, bool>> predicate);
        Task<IResult> AddAsync(User entity);
        Task<IResult> UpdateAsync(User entity);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<UserDto>> GetByEmailAsync(string email);
    }
}
