using AutoMapper;
using BindingModel.V1._0.User;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMVC.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullDestinationValues = true;

            CreateMap<UserBindingModel, User>().ReverseMap();
            CreateMap<UserLoginBindingModel, User>().ReverseMap();
            CreateMap<RegisterUserBindingModel, User>().ReverseMap();
            CreateMap<UserAuthenticationBindingModel, UserAuthentication>().ReverseMap();
        }
    }
}