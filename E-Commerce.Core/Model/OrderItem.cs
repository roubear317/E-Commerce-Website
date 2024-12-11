﻿using E_commerce.EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Model
{
    public  class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }         
        public int OrderId { get; set; }     
        public int ProductId { get; set; }   
        public Product Product { get; set; }  
        public int Quantity { get; set; }     
        public decimal Price { get; set; }    
        public decimal Subtotal { get; set; }

    }
}
