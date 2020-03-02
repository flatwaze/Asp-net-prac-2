using System.Collections.Generic;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;

namespace WebStore.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<ProductDTO> GetProducts(ProductFilter filter);
        ProductDTO GetProductById(int id);

    }
}