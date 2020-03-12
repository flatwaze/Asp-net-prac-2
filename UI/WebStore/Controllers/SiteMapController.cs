using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using WebStore.DomainNew.Filters;
using WebStore.Interfaces.Services;

namespace WebStore.Controllers
{
    public class SiteMapController : Controller
    {
        public IActionResult Index([FromServices] IProductService ProductService)
        {
            var nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index", "Home")),
                new SitemapNode(Url.Action("ContactUs", "Home")),
                new SitemapNode(Url.Action("Blog", "Home")),
                new SitemapNode(Url.Action("BlogSingle", "Home")),
                new SitemapNode(Url.Action("Shop", "Catalog")),
                new SitemapNode(Url.Action("Index", "WebAPITest")),
            };

            nodes.AddRange(ProductService.GetCategories().Select(section => new SitemapNode(Url.Action("Shop", "Catalog", new { SectionId = section.Id }))));

            foreach (var brand in ProductService.GetBrands())
                nodes.Add(new SitemapNode(Url.Action("Shop", "Catalog", new { BrandId = brand.Id })));

            foreach (var product in ProductService.GetProducts(new ProductFilter()))
                nodes.Add(new SitemapNode(Url.Action("Details", "Catalog", new { product.Id })));

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));


        }
    }
}
