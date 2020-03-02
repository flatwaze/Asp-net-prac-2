using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductService
    {
        private readonly IProductService _ProductService;
        public ProductsApiController(IProductService ProductService) => _ProductService = ProductService;

        [HttpGet("categories")]
        public IEnumerable<Category> GetCategories() => _ProductService.GetCategories();

        [HttpGet("brands")]
        public IEnumerable<Brand> GetBrands() => _ProductService.GetBrands();

        [HttpGet("{id}"), ActionName("Get")]
        public ProductDTO GetProductById(int id) => _ProductService.GetProductById(id);

        [HttpPost, ActionName("Post")]
        public IEnumerable<ProductDTO> GetProducts([FromBody]ProductFilter filter) => _ProductService.GetProducts(filter);
    }
}