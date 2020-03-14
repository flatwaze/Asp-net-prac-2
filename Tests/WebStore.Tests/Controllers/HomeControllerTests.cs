﻿using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.DomainNew.DTO.Products;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.DomainNew.Models;
using WebStore.Interfaces.Services;
using WebStore.Models;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void Details_Returns_With_Correct_View()
        {
            const int expected_product_id = 1;
            const decimal expected_price = 10m;

            var expected_name = $"Product id {expected_product_id}";
            var expected_brand_name = $"Brand of product {expected_product_id}";

            var product_data_mock = new Mock<IProductService>();
            product_data_mock
               .Setup(p => p.GetProductById(It.IsAny<int>()))
               .Returns<int>(id => new ProductDTO
               {
                   Id = id,
                   Name = $"Product id {id}",
                   ImageUrl = $"Image_id_{id}.png",
                   Order = 1,
                   Price = expected_price,
                   Brand = new BrandDTO
                   {
                       Id = 1,
                       Name = $"Brand of product {id}"
                   },
                   Category = new CategoryDTO
                   {
                       Id = 1,
                       Name = $"Category of product {id}"
                   }
               });

            var config_mock = new Mock<IConfiguration>();

            var controller = new CatalogController(product_data_mock.Object, config_mock.Object);

            var result = controller.ProductDetails(expected_product_id);

            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(view_result.Model);

            Assert.Equal(expected_product_id, model.Id);
            Assert.Equal(expected_name, model.Name);
            Assert.Equal(expected_price, model.Price);
            Assert.Equal(expected_brand_name, model.Brand);
        }


        [TestMethod]
        public void Details_Returns_NotFound_if_Product_not_Exist()
        {
            const int expected_product_id = 1;

            var product_data_mock = new Mock<IProductService>();
            product_data_mock
               .Setup(p => p.GetProductById(It.IsAny<int>()))
               .Returns(default(ProductDTO));

            var config_mock = new Mock<IConfiguration>();

            var controller = new CatalogController(product_data_mock.Object, config_mock.Object);

            var result = controller.ProductDetails(expected_product_id);

            Assert.IsType<NotFoundResult>(result);
        }

        [TestMethod]
        public void Shop_Returns_Correct_View()
        {
            var products = new[]
            {
                new ProductDTO
                {
                    Id = 1,
                    Name = "Product 1",
                    Order = 0,
                    Price = 10m,
                    ImageUrl = "Product1.png",
                    Brand = new BrandDTO
                    {
                        Id = 1,
                        Name = "Brand of product 1"
                    },
                    Category = new CategoryDTO
                    {
                        Id = 1,
                        Name = "Category of product 1"
                    }
                },
                new ProductDTO
                {
                    Id = 2,
                    Name = "Product 2",
                    Order = 0,
                    Price = 20m,
                    ImageUrl = "Product2.png",
                    Brand = new BrandDTO
                    {
                        Id = 2,
                        Name = "Brand of product 2"
                    },
                    Category = new CategoryDTO
                    {
                        Id = 2,
                        Name = "Category of product 2"
                    }
                },
            };

            var product_data_mock = new Mock<IProductService>();
            product_data_mock
               .Setup(p => p.GetProducts(It.IsAny<ProductFilter>()))
               .Returns<ProductFilter>(filter => new PagedProductsDTO
               {
                   Products = products,
                   TotalCount = products.Length
               });

            var mapper_mock = new Mock<IMapper>();
            mapper_mock
               .Setup(m => m.Map<ProductViewModel>(It.IsAny<ProductDTO>()))
               .Returns<ProductDTO>(p => new ProductViewModel
               {
                   Id = p.Id,
                   Price = p.Price,
                   Name = p.Name,
                   ImageUrl = p.ImageUrl,
                   Brand = p.Brand.Name,
                   Order = p.Order
               });

            var config_mock = new Mock<IConfiguration>();

            var controller = new CatalogController(product_data_mock.Object, config_mock.Object);

            const int expected_Category_id = 1;
            const int expected_brand_id = 5;

            var result = controller.Shop(expected_Category_id, expected_brand_id, mapper_mock.Object);

            var view_result = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<CatalogViewModel>(view_result.ViewData.Model);

            Assert.Equal(2, model.Products.Count());
            Assert.Equal(expected_Category_id, model.CategoryId);
            Assert.Equal(expected_brand_id, model.BrandId);

            Assert.Equal("Brand of product 1", model.Products.First().Brand);
        }
    }
}