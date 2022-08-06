using enairaUHC.src.eNairaServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src.eNairaServices
{
    public interface IEnairaService
    {
        public void CreateEnairaUser(EnairaUserDto user);
    }
}
