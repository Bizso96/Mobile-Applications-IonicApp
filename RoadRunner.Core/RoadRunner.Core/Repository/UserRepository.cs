using RoadRunner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using RoadRunner.Core.Models.APIModels;

namespace RoadRunner.Core.Repository
{
    public class UserRepository
    {
        private RoadRunnerContext _dbContext;
        private string _jwtVerificationString = "TheHistoryOfTomJonesAFoundling";

        public UserRepository(RoadRunnerContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public AuthenticationResponseModel Authenticate(string userName, string password)
        {
            User user = _dbContext.Users.FirstOrDefault(user => user.UserName == userName);

            if (user != null && user.Password == password)
            {
                var token = generateJwtToken(user);

                return new AuthenticationResponseModel(user, token);
            }

            return null;
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtVerificationString);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
