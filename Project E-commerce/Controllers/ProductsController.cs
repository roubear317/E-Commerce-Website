using AutoMapper;
using E_commerce.EF.DTOS;
using E_commerce.EF.Model;
using E_commerce.EF.Repos;
using E_commerce.EF.SpecificClassMethods;
using E_Commerce.Core.Model;
using E_Commerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Project_E_commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController :BaseController
    {
        

        private readonly IGenericRepo<Product> _Productrepo;

        private readonly IGenericRepo<Category> _CategoryRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepo<Product> ProductRepo,IGenericRepo<Category> CategoryRepo,IMapper mapper)
        {
            _Productrepo = ProductRepo;
            _CategoryRepo = CategoryRepo;
            _mapper = mapper;
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProduct(string sort,
            int? CategoryID)
        {

            
            var spec = new ProductIncludesPhotosandCategory(sort ?? "Name" , CategoryID);

            var products= await _Productrepo.GetListOfEntityBySpec(spec);

            //int pagesize = 6;

            //var totalnumber = products.Count();
            //var totalPages = (int)Math.Ceiling((decimal)totalnumber / pagesize);

            //var page = 1;
            //var productsinpage = products.Skip((page-1)*pagesize).Take(pagesize).ToList();
         

            if (products == null) return NotFound();



           
            var productsList = _mapper.Map<IEnumerable<ProductDto>>(products);


            return Ok (productsList);

        }


        [HttpGet("{id}")]

        public async Task<ActionResult<PhotosDto>> GetProductById(int id)
        {

            var spec = new ProductIncludesPhotosandCategory(id);



            var product = await _Productrepo.GetEntityBySpec(spec);

            if (product == null) return NotFound();

           


         
            var productDto = _mapper.Map<Product, ProductDto>(product);
            return Ok (productDto);    

        }


        [HttpGet("Category")]

        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategory()
        {
            var Category = await _CategoryRepo.GetAllAsync();

            if (Category == null) return NotFound();

            return Ok(Category);
        }



        [HttpGet("Category/{categoryName}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategoryName(string categoryName)
        {
            
            var spec = new ProductIncludesPhotosandCategory(categoryName);

            var products = await _Productrepo.GetListOfEntityBySpec(spec);

           
            if (products == null || !products.Any())
            {
                return NotFound($"No products found for category name '{categoryName}'.");
            }

            var productsList = _mapper.Map<IEnumerable<ProductDto>>(products);


            return Ok(productsList);
        }








    }
}
