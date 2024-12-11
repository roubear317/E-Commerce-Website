using E_commerce.EF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Model
{
    public class Photo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } 
        public int PublicId { get; set; }   
        public string Url { get; set; }

        public string Title { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }  
        public Product Product { get; set; }
    }
}
