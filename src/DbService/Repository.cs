using enairaUHC.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.DbService
{
    public class Repository:IRepository
    {
        EnairaDbContext _enairaDbContext;
        public Repository(EnairaDbContext enairaDbContext) 
        {
            _enairaDbContext = enairaDbContext;
        }

        public async Task CreateUserAsync(User user)
        {
            var dbUser =await  _enairaDbContext.Users.FindAsync(user.BVN);
            if (dbUser != null)
            {
                throw new Exception("Cannot register User");
            }

            await _enairaDbContext.Users.AddAsync(user);
            await _enairaDbContext.SaveChangesAsync();
            return;
        }
    }
}
