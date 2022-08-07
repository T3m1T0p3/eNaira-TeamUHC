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

        public async Task CreateUserAsync(User user,EnairaUserDto enairaUserDto)
        {
            var dbUser =await  _enairaDbContext.Users.FindAsync(user.BVN);
            if (dbUser != null)
            {
                throw new Exception("Cannot register User");
            }
            EnairaUser enairaUser = _mapper.Map<EnairaUser>(enairaUserDto);
            var enairauser = _enairaService.GetEnairaUser(enairaUserDto.phone,enairaUserDto.password);
            if (enairauser != null) return;
            var response=await _enairaService.CreateEnairaUserAsync(enairaUserDto);
            await _enairaDbContext.ENairerUsers.AddAsync(enairaUser);
            await _enairaDbContext.Users.AddAsync(user);
            await _enairaDbContext.SaveChangesAsync();
            return;
        }
        public async Task CreateUserAsync(User user)
        {
            var dbUser = await _enairaDbContext.Users.FindAsync(user.BVN);
            if (dbUser != null)
            {
                throw new Exception("Cannot register User");
            }
            await _enairaDbContext.Users.AddAsync(user);
            await _enairaDbContext.SaveChangesAsync();
            return;
        }

        public async Task<User> GetUserAsync(string Bvn)
        {
            var user =await _enairaDbContext.Users.FindAsync(Bvn);
            if (user == null) throw new Exception("Not Found");
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
