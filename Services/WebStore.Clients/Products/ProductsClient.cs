﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Interfaces.API;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Values
{
    
    public class ProductsClient : BaseClient, IProductService
    {
        public ProductsClient(IConfiguration config) : base(config, "api/products") { }

        public IEnumerable<BrandDTO> GetBrands() => Get<List<BrandDTO>>($"{_ServiceAddress}/brands");

        public CategoryDTO GetCategoryById(int id) => Get<CategoryDTO>($"{_ServiceAddress}/sections/{id}");

        public BrandDTO GetBrandById(int id) => Get<BrandDTO>($"{_ServiceAddress}/brands/{id}");

        public IEnumerable<CategoryDTO> GetCategories() => Get<List<CategoryDTO>>($"{_ServiceAddress}/categories");

        public ProductDTO GetProductById(int id) => Get<ProductDTO>($"{_ServiceAddress}/{id}");

        public PagedProductsDTO GetProducts(ProductFilter filter = null) => Post(_ServiceAddress, filter).Content.ReadAsAsync<PagedProductsDTO>().Result;
    }
}
