using AutoMapper;
using E_commerce.EF.DTOS;
using E_commerce.EF.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.EF.Helpers
{
   


    public class UrlHelper : IValueResolver<Product, ProductDto, ICollection<PhotosDto>>
    {
        private readonly IConfiguration _config;

        public UrlHelper(IConfiguration config)
        {
            _config = config;
        }

        public ICollection<PhotosDto> Resolve(Product source, ProductDto destination, ICollection<PhotosDto> destMember, ResolutionContext context)
        {
            if (source.photo == null || !source.photo.Any())
                return new List<PhotosDto>();

            return source.photo.Select(photo => new PhotosDto
            {
                Id = photo.Id,
                Url = $"{_config["ApiUrl"]}{photo.Url}",
                Title = photo.Title,
                PublicId = photo.PublicId
            }).ToList();
        }
    }













}
