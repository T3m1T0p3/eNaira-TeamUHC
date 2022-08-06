using enairaUHC.src.eNairaServices;
using enairaUHC.src.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.DbService
{
    public interface IRepository
    {
        public Task CreateUserAsync(User user,EnairaUser enairaUser);
        public Task<User> GetUserAsync(string bvn);
        public Task AddInsurerAsync(Insurer proiver);
    }
}
