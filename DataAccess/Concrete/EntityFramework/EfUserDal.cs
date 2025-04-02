using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfGenericRepository<User, SouthwindContext>, IUserDal
    {
        public async Task<User> GetByEmailAsync(string email)
        {
            using var context = new SouthwindContext();
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == email); // ayni email bir daha tekrarlanmamali kontrolunu yaz
            return user;
        }
    }
}
