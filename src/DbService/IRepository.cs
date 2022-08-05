using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.DbService
{
    public interface IRepository
    {
        public Task CreateUserAsync(User user);
    }
}
