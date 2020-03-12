using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Models;
using WebStore.Interfaces.Services;
using WebStore.Models;

namespace WebStore.ViewComponents
{
    [ViewComponent(Name="Cats")]
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public CategoriesViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string CategoryId)
        {
            var category_id = int.TryParse(CategoryId, out var id) ? id : (int?)null;

            var categories = GetCategories(category_id, out var parent_category_id);

            return View(new CategoryCompleteViewModel { Categories = categories, 
                CurrentParentCategoryId = parent_category_id, 
                CurrentCategoryId = category_id});
        }

        private IEnumerable<CategoryViewModel> GetCategories(int? CategoryId, out int? ParentCategoryId)
        {
            ParentCategoryId = null;
            var categories = _productService.GetCategories();

            var parentSections = categories.Where(x => !x.ParentId.HasValue).ToArray();
            var parentCategories = new List<CategoryViewModel>();
            
            foreach (var parentCategory in parentSections)
            {
                parentCategories.Add(new CategoryViewModel()
                {
                    Id = parentCategory.Id,
                    Name = parentCategory.Name,
                    Order = parentCategory.Order,
                    ParentCategory = null
                });
            }

            
            foreach (var CategoryViewModel in parentCategories)
            {
                var childCategories = categories.Where(x => x.ParentId == CategoryViewModel.Id);
                foreach (var childCategory in childCategories)
                {
                    if (childCategory.Id == CategoryId)
                        ParentCategoryId = CategoryViewModel.Id;

                    CategoryViewModel.ChildCategories.Add(new CategoryViewModel()
                    {
                        Id = childCategory.Id,
                        Name = childCategory.Name,
                        Order = childCategory.Order,
                        ParentCategory = CategoryViewModel
                    });
                }
                CategoryViewModel.ChildCategories = CategoryViewModel.ChildCategories.OrderBy(x => x.Order).ToList();
            }

            parentCategories = parentCategories.OrderBy(x => x.Order).ToList();
            return parentCategories;

        }
    }
}
