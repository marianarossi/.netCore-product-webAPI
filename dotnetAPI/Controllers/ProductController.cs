using dotnetAPI.models;
using dotnetAPI.Models.DTOs;
using dotnetAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnetAPI.Controllers
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
            var products = await _productService.getProducts();
            if (products.Status == false) //not found
            {
                return NotFound(products);
            }

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var products = await _productService.getProductById(id);
            if (products.Status == false)
            {
                return NotFound(products);
            }
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            var products = await _productService.createProduct(createProductDTO);
            if(products.Status == false)
            {
                return BadRequest(products);
            }
            return Ok(products);
        }

        [HttpPut]
        public async Task<IActionResult> EditProduct(EditProductDTO editProductDTO)
        {
            var products = await _productService.editProduct(editProductDTO);

            if(products.Status == false)
            {
                return BadRequest(products);
            }
            return Ok(products);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var products = await _productService.removeProduct(id);

            if (products.Status == false)
            {
                return BadRequest(products);
            }
            return Ok(products);
        }
    }
}
