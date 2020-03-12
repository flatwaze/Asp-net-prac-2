using System;
using System.Collections.Generic;
using System.Text;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;

namespace WebStore.Services.Mapping
{
    public static class CategoryMapper
    {
        public static CategoryDTO ToDTO(this Category Category) => Category is null ? null : new CategoryDTO
        {
            Id = Category.Id,
            Name = Category.Name
        };

        public static Category FromDTO(this CategoryDTO Category) => Category is null ? null : new Category
        {
            Id = Category.Id,
            Name = Category.Name
        };
    }
}