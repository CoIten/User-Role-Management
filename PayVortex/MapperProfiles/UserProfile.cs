﻿using ApplicationCore.Models.Users;
using AutoMapper;
using BusinessLayer.Models.Users;
using Web.DTOs.User;

namespace Web.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserPostDTO, UserPost>();
            CreateMap<UserUpdateDTO, UserUpdate>();
            CreateMap<User, UserDTO>();
        }
    }
}
