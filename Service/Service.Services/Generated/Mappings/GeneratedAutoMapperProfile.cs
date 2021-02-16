
using System;
using AutoMapper;
using Service.Domain;
using Service.Models;

namespace Service.Services
{
    public class GeneratedAutoMapperProfile:Profile
    {
        public GeneratedAutoMapperProfile()
        {
           
           CreateMap<Address, AddressDto>();
           CreateMap<AddressDto,Address>();
           
           CreateMap<User, UserDto>();
           CreateMap<UserDto,User>();
           
           CreateMap<UserFollowings, UserFollowingsDto>();
           CreateMap<UserFollowingsDto,UserFollowings>();
        
        }
    }
}