using System.Collections.Generic;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;

namespace WebStore.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();

        CategoryDTO GetCategoryById(int id);
        IEnumerable<Brand> GetBrands();

        BrandDTO GetBrandById(int id);
        IEnumerable<ProductDTO> GetProducts(ProductFilter filter);
        ProductDTO GetProductById(int id);

    }
}