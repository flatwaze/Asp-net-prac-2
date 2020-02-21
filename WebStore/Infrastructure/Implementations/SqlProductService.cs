using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.FIlters;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
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

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = _context.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(x => x.BrandId.HasValue && x.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.CategoryId.HasValue)
                query = query.Where(x => x.CategoryId.Equals(filter.CategoryId.Value));
           
            return query.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products
                .Include(x => x.Category)
                .Include(x => x.Brand)
                .FirstOrDefault(x => x.Id == id);
        }

    }
}
