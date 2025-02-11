using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> Get() => await _productService.GetProductsAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> Get(string id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        return product is not null ? Ok(product) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _productService.CreateProductAsync(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Product product)
    {
        var updated = await _productService.UpdateProductAsync(id, product);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _productService.DeleteProductAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
