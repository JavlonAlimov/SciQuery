using AutoMapper;
using SciQuery.Domain.UserModels;
using SciQuery.Service.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciQuery.Service.Mappings;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<UserForCreateDto, User>();
        CreateMap<UserForUpdatesDto, User>();
    }
}
