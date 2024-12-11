using E_commerce.EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Model
{
   public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }


        public string Name { get; set; }


        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
       // public ICollection<Product> Products { get; set; } = new HashSet<Product>();




    }
}
