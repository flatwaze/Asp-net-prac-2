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
using WebStore.Services.Mapping;

namespace WebStore.Services.Implementations
{
    public class SqlProductService : IProductService
    {
        private readonly WebStoreContext _context;

        public SqlProductService(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            return _context.Categories.ToDTO().ToList();
        }

        public IEnumerable<BrandDTO> GetBrands()
        {
           return _context.Brands.ToDTO().ToList();
        }

        public PagedProductsDTO GetProducts(ProductFilter filter)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(x => x.BrandId.HasValue && x.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                query = query.Where(x => x.CategoryId.Equals(filter.CategoryId.Value));

            /*return query
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
                });*/
            if (filter?.Ids?.Count > 0)
            {
                query = query.Where(x => filter.Ids.Contains(x.Id));
            }
            var total_count = query.Count();

            if (filter?.PageSize != null)
                query = query
                   .Skip((filter.Page - 1) * (int)filter.PageSize)
                   .Take((int)filter.PageSize);

            return new PagedProductsDTO
            {
                Products = query.AsEnumerable().ToDTO(),
                TotalCount = total_count
            };
        }

        public ProductDTO GetProductById(int id)
        {
            return _context.Products
               .Include(p => p.Brand)
               .Include(p => p.Category)
               .FirstOrDefault(p => p.Id == id).ToDTO();
        }

        public CategoryDTO GetCategoryById(int id) => _context.Categories.Find(id).ToDTO();
        public BrandDTO GetBrandById(int id) => _context.Brands.Find(id).ToDTO();

    }
}
