using Microsoft.AspNetCore.Mvc;
using Store.Api.Controllers;
using System;
using Xunit;

namespace Store.Test
{
    public class UnitTest1
    {
        [Fact]
        public void GetProductsFromControllerTest()
        {
            var controller = new ProductController(logger: null);
            var result = controller.Get();

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetProductFromControllerTest()
        {
            var controller = new ProductController(logger: null);
            var productMock = new Ado.Models.Product()
            {
                Id = new Guid("1e8f8f6d-f8c1-4b5f-b8e2-f8f8f8f8a818"),
                Name = "Product 1",
                Stock = 10,
                CategoryId = new Guid("3ba82a90-2086-49e9-99a2-09f844a21d37")
            };

            var result = controller.Post(productMock);

            Assert.IsType<CreatedAtActionResult>(result);

            var result2 = controller.Get(productMock.Id);

            Assert.IsType<OkObjectResult>(result2);

            var result3 = controller.Delete(productMock.Id);

            Assert.IsType<OkObjectResult>(result3);
        }

        [Fact]
        public void GetProductFromControllerWithMockTest()
        {
            var controller = new ProductController(logger: null);
            var productMock = new Ado.Models.Product()
            {
                Id = new Guid("1e8f8f6d-f8c1-4b5f-b8e2-f8f8f8f8a818"),
                Name = "Product 1",
                Stock = 10,
                CategoryId = new Guid("3ba82a90-2086-49e9-99a2-09f844a21d37")
            };

            var result = controller.Post(productMock);

            Assert.IsType<CreatedAtActionResult>(result);

            var resultDelete = controller.Delete(productMock.Id);

            Assert.IsType<OkObjectResult>(resultDelete);
        }

        [Fact]
        public void UpdateProductFromControllerWithMockTest()
        {
            var controller = new ProductController(logger: null);
            var productMock = new Ado.Models.Product()
            {
                Id = new Guid("1e8f8f6d-f8c1-4b5f-b8e2-f8f8f8f8a818"),
                Name = "Product 1",
                Stock = 10,
                CategoryId = new Guid("3ba82a90-2086-49e9-99a2-09f844a21d37")
            };

            var result = controller.Post(productMock);

            Assert.IsType<CreatedAtActionResult>(result);

            productMock.Name = "Product 1 Updated";

            var resultUpdate = controller.Put(productMock);

            Assert.IsType<OkObjectResult>(resultUpdate);

            var resultDelete = controller.Delete(productMock.Id);

            Assert.IsType<OkObjectResult>(resultDelete);
        }
    }
}
