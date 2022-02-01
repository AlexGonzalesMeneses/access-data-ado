using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Store.Ado.Models;
using Store.Api;
using Xunit;

namespace Store.Test.ProductTests
{
    public class ProductIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient httpClient;
        public ProductIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            httpClient = factory.CreateDefaultClient();
        }

        [Fact]
        public async void ProductGet_ReturnsOk()
        {
            var response = await httpClient.GetAsync("/Product");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ProductGetById_ReturnsOk()
        {
            var response = await httpClient.GetAsync("/Product/5dda0c17-1fe4-4c28-a6ad-12f92c89fb36");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void ProductGetById_ReturnsNotFound()
        {
            var response = await httpClient.GetAsync("/Product/aadaac17-1fe4-4c28-a6ad-12f92c89fb36");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async void ProductSpecificDelete_ReturnOk()
        {
            var response = await httpClient.DeleteAsync("/Product/1e8f8f6d-f8c1-4b5f-b8e2-f8f8f8f8a818");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void ProductPost_ReturnOk()
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Stock = 10,
                CategoryId = new Guid("3ba82a90-2086-49e9-99a2-09f844a21d37")
            };

            var response = await httpClient.PostAsJsonAsync<Product>("/Product", product);

            response.EnsureSuccessStatusCode();
        }
    }
}