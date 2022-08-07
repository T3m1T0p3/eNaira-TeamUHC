using AutoMapper;
using enairaUHC.src.eNairaServices;
using enairaUHC.src.eNairaServices.Dto;
using enairaUHC.src.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.src
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            //CreateMap<EnairaUser, string>();//.ForMember(dst => dst.account_no, src => src.MapFrom(acc => acc.AccountNumber)).
            // ForMember(dst => dst.customer_tier, src => src.MapFrom(customer => customer.CustomerTier)).
            // ForMember(dst => dst.channel_code, src => src.MapFrom(channel => channel.ChannelCode));

            CreateMap<EnairaUserResponseBody, string>().ReverseMap();
            CreateMap<CustomerIdResponse, string>().ReverseMap();
            CreateMap<EnairaGetUserResponseData, string>().ReverseMap();
            CreateMap<CustomerAccountDetailsResponse, string>().ReverseMap();
            CreateMap<EnairaUser, EnairaUserDto>().ReverseMap();
            
        }
    }
}
