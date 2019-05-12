namespace WebAppMVC.Infrastructure.AutoMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BindingModel.V1._0.User;
    using BindingModel.V1._0.User.Role;
    using Domain.User;
    using Domain.User.Role;
    using global::AutoMapper;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            AllowNullDestinationValues = true;

            #region User

            CreateMap<UserBindingModel, User>().ReverseMap();
            CreateMap<UserLoginBindingModel, User>().ReverseMap();
            CreateMap<RegisterUserBindingModel, User>().ReverseMap();
            CreateMap<UserAuthenticationBindingModel, UserAuthentication>().ReverseMap();
            CreateMap<UserRoleBindingModel, UserRole>().ReverseMap();

            #endregion User
        }
    }
}