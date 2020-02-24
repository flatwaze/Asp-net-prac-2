using System.Collections.Generic;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;

namespace WebStore.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Brand> GetBrands();
        IEnumerable<Product> GetProducts(ProductFilter filter);
        Product GetProductById(int id);

    }
}