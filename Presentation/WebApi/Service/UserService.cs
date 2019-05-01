namespace WebApi.Service
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using BindingModel.User;
    using BindingModel.V1._0;
    using BindingModel.V1._0.User;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using WebApi.Infrastructure.Helpers;
    using WebApi.Repository;

    public interface IUserService
    {
        bool CreateUser(UserBindingModel userLogin);

        UserBindingModel GetUserByName(UserBindingModel userLogin);

        bool UpdateUser(UserBindingModel userBindingModel);

        bool DeleteUser(UserBindingModel userBindingModel);

        UserAuthenticationBindingModel Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly EFDataContext _dbContext = new EFDataContext();

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            this._appSettings = appSettings.Value;
        }

        public bool CreateUser(UserBindingModel userLogin)
        {
            this._dbContext.Users.Add(userLogin);
            this._dbContext.SaveChanges();
            return true;
        }

        public UserAuthenticationBindingModel Authenticate(string username, string password)
        {
            var user = this._dbContext.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
            {
                return null;
            }

            UserAuthenticationBindingModel userAuthentication = new UserAuthenticationBindingModel()
            {
                LoggedOn = DateTime.Now,
                ExpiresOn = DateTime.UtcNow.AddDays(7)
            };

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = userAuthentication.ExpiresOn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            userAuthentication.Token = tokenHandler.WriteToken(token);

            return userAuthentication;
        }

        public UserBindingModel GetUserByName(UserBindingModel userLogin)
        {
            return this._dbContext.Users.FirstOrDefault(
                                               x => x.UserName == userLogin.UserName

                                            );
        }

        public bool UpdateUser(UserBindingModel userBindingModel)
        {
            var user = this._dbContext.Users.FirstOrDefault(x => x.UserName == userBindingModel.UserName);
            user = userBindingModel;
            this._dbContext.SaveChanges();

            return true;
        }

        public bool DeleteUser(UserBindingModel userBindingModel)
        {
            var user = this._dbContext.Users.FirstOrDefault(x => x.UserName == userBindingModel.UserName);
            this._dbContext.Users.Remove(user);
            this._dbContext.SaveChanges();

            return true;
        }
    }
}