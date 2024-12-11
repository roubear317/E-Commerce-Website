﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Model
{
    public  class User
    {

      public  int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }



        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }
    }
}
