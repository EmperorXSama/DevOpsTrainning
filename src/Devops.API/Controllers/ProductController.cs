// src/Devops.API/Controllers/ProductController.cs
using Devops.Application;
using Microsoft.AspNetCore.Mvc;

namespace Devops.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _service.GetAllProductsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _service.GetProductByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromQuery] string name,
        [FromQuery] decimal price,
        [FromQuery] Guid categoryId)
    {
        var product = await _service.CreateProductAsync(name, price, categoryId);
        if (product == null) return BadRequest();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteProductAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}