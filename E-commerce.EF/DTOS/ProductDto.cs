using E_Commerce.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.DTOS
{
    public class ProductDto
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }

        public ICollection<PhotosDto> photo { get; set; }
       
        public float? Rating { get; set; }
        public int? ReviewsCount { get; set; }
        public int? Stock { get; set; }
        public bool? IsNew { get; set; }

        public bool? IsBestSeller { get; set; }
        public bool? IsInWishlist { get; set; }
        public bool? IsInCart { get; set; }

       
        
        public string category { get; set; }


    }
}
