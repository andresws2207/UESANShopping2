using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UESAN.SHOPPING.CORE.Core.DTOs;
using UESAN.SHOPPING.CORE.Core.Entities;
using UESAN.SHOPPING.CORE.Core.Interfaces;

namespace UESAN.SHOPPING.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDTO productCreateDTO)
        {
            if (productCreateDTO == null)
            {
                return BadRequest();
            }

            await _productService.CreateProduct(productCreateDTO);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductUpdateDTO productUpdateDTO)
        {
            if (productUpdateDTO == null)
            {
                return BadRequest();
            }
            var existingProduct = await _productService.GetProductById(productUpdateDTO.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await _productService.UpdateProduct(productUpdateDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromBody] ProductDeleteDTO productDeleteDTO)
        {
            var existingProduct = await _productService.GetProductById(productDeleteDTO.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            await _productService.DeleteProduct(productDeleteDTO);
            return NoContent();
        }
    }
}
