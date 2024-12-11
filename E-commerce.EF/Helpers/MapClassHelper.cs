using AutoMapper;
using E_commerce.EF.DTOS;
using E_commerce.EF.Model;
using E_Commerce.Core.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.Helpers
{
    public class MapClassHelper : Profile
    {

        public MapClassHelper()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.category, opt => opt.MapFrom(src => src.category != null ? src.category.Name : ""))
                .ForMember(dest => dest.photo, opt => opt.MapFrom<UrlHelper>());

            CreateMap<Photo, PhotosDto>();
        }
      

    }
}
