using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Model
{
    public  class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }          
        public int UserId { get; set; }       
        public DateTime OrderDate { get; set; } 
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalAmount { get; set; }

        public Payment Payment { get; set; }
    }

}

