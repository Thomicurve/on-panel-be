using Application;
using Application.IServices;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Controller;

[Authorize]
[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetAllProducts()
    {
        try
        {
            ICollection<ProductDto> products = _productService.GetAllProducts();
            return Ok(products);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        try
        {
            ProductDto product = _productService.GetProductById(id);
            return Ok(product);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public IActionResult UpdateProduct(ProductDto product)
    {
        try
        {
            bool updateResult = _productService.UpdateProduct(product);
            return Ok(updateResult);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult DeleteProduct(int id)
    {
        try
        {
            bool deleteResult = _productService.DeleteProduct(id);
            return Ok(deleteResult);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}
