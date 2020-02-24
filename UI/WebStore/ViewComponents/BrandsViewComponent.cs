using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Services;
using WebStore.Models;

namespace WebStore.ViewComponents
{
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public BrandsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = GetBrands();
            return View(brands);
        }

        private IEnumerable<BrandViewModel> GetBrands()
        {
            var dbBrands = _productService.GetBrands();
            return dbBrands.Select(x => new BrandViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Order = x.Order,
                ProductsCount = 0
            }).OrderBy(x => x.Order).ToList();
        }
    }

}
