using BindingModel.User;
using BindingModel.v1._0;
using BindingModel.v1._0.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Infrastructure.Helpers;
using WebApi.Repository;

namespace WebApi.Service
{
    public interface IUserService
    {
        bool CreateUser(UserBindingModel userLogin);

        UserBindingModel GetUserByName(UserBindingModel userLogin);

        bool UpdateUser(UserBindingModel userBindingModel);

        bool DeleteUser(UserBindingModel userBindingModel);

        UserAuthenticationBindingModel Authenticate(string username, string password);

        IEnumerable<UserBindingModel> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly EFDataContext _dbContext = new EFDataContext();

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserBindingModel> _users = new List<UserBindingModel>
        {
            new UserBindingModel { UserId = 1, FirstName = "Test", LastName = "User", UserName = "test", Password = "test" }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public bool CreateUser(UserBindingModel userLogin)
        {
            _dbContext.Users.Add(userLogin);
            _dbContext.SaveChanges();
            return true;
        }

        public UserAuthenticationBindingModel Authenticate(string username, string password)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.UserName == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            UserAuthenticationBindingModel userAuthentication = new UserAuthenticationBindingModel();
            userAuthentication.LoggedOn = DateTime.Now;
            userAuthentication.ExpiresOn = DateTime.UtcNow.AddDays(7);

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
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

        public IEnumerable<UserBindingModel> GetAll()
        {
            // return users without passwords
            return _users.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }

        public UserBindingModel GetUserByName(UserBindingModel userLogin)
        {
            return _dbContext.Users.FirstOrDefault(
                                               x => x.UserName == userLogin.UserName

                                            );
        }

        public bool UpdateUser(UserBindingModel userBindingModel)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == userBindingModel.UserName);
            user = userBindingModel;
            _dbContext.SaveChanges();

            return true;
        }

        public bool DeleteUser(UserBindingModel userBindingModel)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.UserName == userBindingModel.UserName);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return true;
        }
    }
}