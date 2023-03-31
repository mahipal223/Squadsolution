using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Net_Web_API.Dtos;
using Asp.Net_Web_API.model;
using AutoMapper;

namespace Asp.Net_Web_API.handlers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto,User>();
        }
    }
}