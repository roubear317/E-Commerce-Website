using E_Commerce.Core.Model;
using E_Commerce.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.Repos
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        //public Task GetTokenAsync()
        //{
        //    var claims =
        //}

        public  TokenService(IConfiguration config ) {
            _config = config;
            _key =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:key"]));
        }
        public  string GetTokenAsync(AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName,user.UserName)
            };


            var Creds= new SigningCredentials(_key,SecurityAlgorithms.HmacSha256);



            var TokenDiscriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = Creds,
                Issuer = _config["Token:Issuer"]
            };

            var TokenHandler = new JwtSecurityTokenHandler();

            var Token = TokenHandler.CreateToken(TokenDiscriptor);

            return  TokenHandler.WriteToken(Token);
        }
    }
}
