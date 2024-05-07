using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_asp_net2.Domain.Identity;

namespace blog_asp_net2.Persistence.Contratos
{
    public interface IUserPersist : IGeralPersist
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUserNameAsync(string userName);
    }
}