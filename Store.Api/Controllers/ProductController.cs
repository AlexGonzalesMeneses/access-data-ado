using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Store.Ado.ManagerClasses;
using Store.Ado.Models;
using Store.Ado.QueryBuilders;
using Store.Ado.Repositories;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;

        public ProductController(ILogger<ProductController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ProductManager.GetProduct());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var product = ProductManager.GetProduct(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                product.Id = product.Id == Guid.Empty ? Guid.NewGuid() : product.Id;
                ProductManager.AddProduct(product);
                return CreatedAtAction("Product created succesfully", product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            try
            {
                ProductManager.UpdateProduct(product);
                return Ok("Product updated succesfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                ProductManager.DeleteProduct(id);
                return Ok("Product deleted succesfully");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}