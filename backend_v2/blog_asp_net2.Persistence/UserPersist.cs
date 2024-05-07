using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_asp_net2.Domain.Identity;
using blog_asp_net2.Persistence.Contextos;
using blog_asp_net2.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

namespace blog_asp_net2.Persistence
{
    public class UserPersist : GeralPersist, IUserPersist
    {
         private readonly DataContext _context;
        public UserPersist(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
        }

    }
}