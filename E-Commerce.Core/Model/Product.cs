using E_Commerce.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.Model
{
    public class Product
    {


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        //public string ImageUrl { get; set; }  

        //public Photo[] photo { get;set; }
        public ICollection<Photo> photo { get; set; }
        // public string Category { get; set; } 
        public float? Rating { get; set; } 
        public int? ReviewsCount { get; set; }  
        public int? Stock { get; set; }  
        public bool? IsNew { get; set; }

        public bool? IsBestSeller { get; set; }
        public bool? IsInWishlist { get; set; }  
        public bool? IsInCart { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
