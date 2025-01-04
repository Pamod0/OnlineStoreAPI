using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Dto;
using OnlineStore.Interfaces.ProductInterfaces;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productRepository.GetAllProducts());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(products);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var product = _mapper.Map<Product>(productDto);
            if (!_productRepository.CreateProduct(product.CategoryId, product))
            {
                ModelState.AddModelError("", $"Something went wrong saving the record {product.Name}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
