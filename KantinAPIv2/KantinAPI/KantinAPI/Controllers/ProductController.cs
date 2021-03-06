using AutoMapper;
using KantinAPI.Business.Abstract;
using KantinAPI.DTO.Product;
using KantinAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Controllers
{
 
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productService.GetAll();

            return Ok(_mapper.Map<List<ProductListDto>>(products.Where(x => x.IsActive == true)));
        }
        [HttpPost]
        [Route("[controller]/productAdd")]
        public async Task<IActionResult> AddProduct([FromBody] ProductAddDto model)
        {

            var product = await _productService.Create(_mapper.Map<Product>(model));
            if (product != null)
            {
                return Ok(_mapper.Map<Product>(product));
            }
            return BadRequest("Bir hata oluştu.");
        }
        [HttpPut]
        [Route("[controller]/productUpdate/{productId}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int productId, [FromBody] ProductUpdateDto model)
        {


            var product = _productService.ExistProduct(productId);
            if (product)
            {
                var updateProduct = await _productService.Update(_mapper.Map<Product>(model));
                if (updateProduct != null)
                {
                    return Ok(_mapper.Map<Product>(updateProduct));
                }
                return NotFound();
            }
            return BadRequest("Bir hata oluştu.");
        }
        [HttpPut]
        [Route("[controller]/productDelete/{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {


            var product = _productService.ExistProduct(productId);
            if (product)
            {
                var updateProduct = await _productService.DeleteProduct(productId);
                if (updateProduct!=null)
                {
                    return Ok(_mapper.Map<Product>(updateProduct));
                }
                return NotFound();
            }
            return BadRequest("Bir hata oluştu.");
        }

    }
}
