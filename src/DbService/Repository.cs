using AutoMapper;
using enairaUHC.AppDbContext;
using enairaUHC.src.eNairaServices;
using enairaUHC.src.eNairaServices.Dto;
using enairaUHC.src.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.DbService
{
    public class Repository:IRepository
    {
        EnairaDbContext _enairaDbContext;
        IEnairaService _enairaService;
        IMapper _mapper;
        public Repository(EnairaDbContext enairaDbContext, IEnairaService eNairaService,IMapper mapper)
        {
            _enairaDbContext = enairaDbContext;
            _enairaService = eNairaService;
            _mapper = mapper;
        }

        public async Task CreateUserAsync(User user,EnairaUser enairaUser)
        {
            var dbUser =await  _enairaDbContext.Users.FindAsync(user.BVN);
            if (dbUser != null)
            {
                throw new Exception("Cannot register User");
            }
            EnairaUserDto enairaUserDto = _mapper.Map<EnairaUserDto>(enairaUser);
            _enairaService.CreateEnairaUser(enairaUserDto);

            await _enairaDbContext.ENairerUsers.AddAsync(enairaUser);
            await _enairaDbContext.Users.AddAsync(user);
            await _enairaDbContext.SaveChangesAsync();
            return;
        }

        public async Task<User> GetUserAsync(string Bvn)
        {
            var user =await _enairaDbContext.Users.FindAsync(Bvn);
            if (user == null) throw new Exception("Invalid User");
            return user;
        }

        public async Task AddInsurerAsync(Insurer provider)
        {
            var insurer=await _enairaDbContext.Insurers.FindAsync(provider.InsurerId);
            if (insurer != null)
            {
                throw new Exception("Provider Already exists");
            }
            await _enairaDbContext.Insurers.AddAsync(provider);
            _enairaDbContext.SaveChanges();
            return;
        }

    }
}
