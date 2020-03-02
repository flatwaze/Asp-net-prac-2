using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Interfaces.Services;

namespace WebStore.Services.Implementations
{
    public class SqlProductService : IProductService
    {
        private readonly WebStoreContext _context;

        public SqlProductService(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public IEnumerable<Brand> GetBrands()
        {
           return _context.Brands.ToList();
        }

        public IEnumerable<ProductDTO> GetProducts(ProductFilter filter)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(x => x.BrandId.HasValue && x.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                query = query.Where(x => x.CategoryId.Equals(filter.CategoryId.Value));

            return query
                .AsEnumerable()
                .Select(p => new ProductDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Brand = p.Brand is null ? null : new BrandDTO
                    {
                        Id = p.Brand.Id,
                        Name = p.Brand.Name
                    },
                    Category = p.Category is null ? null : new CategoryDTO
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name
                    }
                });
        }

        public ProductDTO GetProductById(int id)
        {
            var product = _context.Products
               .Include(p => p.Brand)
               .Include(p => p.Category)
               .FirstOrDefault(p => p.Id == id);
            return product is null ? null : new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Order = product.Order,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Brand = product.Brand is null ? null : new BrandDTO
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                },
                Category = product.Category is null ? null : new CategoryDTO
                {
                    Id = product.Category.Id,
                    Name = product.Category.Name
                }
            };
        }

    }
}
