using System.Collections.Generic;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;

namespace WebStore.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<CategoryDTO> GetCategories();

        CategoryDTO GetCategoryById(int id);
        IEnumerable<BrandDTO> GetBrands();

        BrandDTO GetBrandById(int id);
        PagedProductsDTO GetProducts(ProductFilter filter);
        ProductDTO GetProductById(int id);

    }
}