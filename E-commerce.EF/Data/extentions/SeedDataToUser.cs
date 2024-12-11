using E_Commerce.Core.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.Data.extentions
{
    public static class SeedDataToUser
    {


        public   static async Task SeedDataUserAsync(UserManager<AppUser> usermanager)
        {
            if(!usermanager.Users.Any())
            {
                var user = new AppUser()
                {
                    FullName = "Robear Atef",
                    Email = "Rob@gmail.com",


                };

                 await usermanager.CreateAsync(user, "Pa$$w0rd");

            }




        }


    }
}
