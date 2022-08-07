using AutoMapper;
using enairaUHC.AppDbContext;
using enairaUHC.src.eNairaServices;
using enairaUHC.src.eNairaServices.Dto;
using enairaUHC.src.Entity;
using Newtonsoft.Json;
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
            Console.WriteLine("Reppsitory CreateUserAsync Hit");
            var dbUser =await  _enairaDbContext.Users.FindAsync(user.BVN);
            if (dbUser != null)
            {
                throw new Exception("Cannot register User");
            }
            Console.WriteLine("Calling GetEnairaUser");
            var text = await _enairaService.GetEnairaUser(enairaUserDto.phone, enairaUserDto.password);
            Console.WriteLine(await text.Content.ReadAsStringAsync());

            EnairaUserResponseBody enairauser = JsonConvert.DeserializeObject<EnairaUserResponseBody>(await text.Content.ReadAsStringAsync());// _mapper.Map<EnairaUserResponseBody>(await text.Content.ReadAsStringAsync());
            Console.WriteLine(enairauser.response_code);
            if (enairauser.response_code != "00") {
                var response = await _enairaService.CreateEnairaUserAsync(enairaUserDto);
                EnairaUser enairaUser = _mapper.Map<EnairaUser>(enairaUserDto);
                await _enairaDbContext.ENairaUsers.AddAsync(enairaUser);
            }
            Console.WriteLine("Saving...");
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
