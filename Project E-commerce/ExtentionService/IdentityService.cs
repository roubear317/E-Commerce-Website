using E_commerce.EF.Context;
using E_Commerce.Core.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Project_E_commerce.ExtentionService
{
    public static class IdentityService
    {


        public static  IServiceCollection AddIdentityService(this IServiceCollection services,
            IConfiguration config)
        {

            var builder = services.AddIdentityCore<AppUser>();



            builder = new IdentityBuilder(builder.UserType,builder.Services);


            builder.AddEntityFrameworkStores<AppDbContext>();

            builder.AddSignInManager<SignInManager<AppUser>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                    ValidateIssuer = true,
                    ValidIssuer = config["Token:Issuer"],
                    
                    ValidateAudience = false,

                }
                );

            return services;



        }




    }
}
