using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebStore.DomainNew.DTO.Products;

namespace WebStore.Services.Mapping
{
    public static class ProductMapper
    {
        public static ProductDTO ToDTO(this WebStore.DomainNew.Entities.Product product) => product is null ? null : new ProductDTO
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

        public static IEnumerable<ProductDTO> ToDTO(this IEnumerable<WebStore.DomainNew.Entities.Product> Products) =>
            Products?.Select(ToDTO);
    }
}
