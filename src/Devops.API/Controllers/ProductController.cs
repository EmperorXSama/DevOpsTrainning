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
    public IActionResult GetAll()
        => Ok(_service.GetAllProducts());

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var product = _service.GetProductById(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create(string name, decimal price)
    {
        var product = _service.CreateProduct(name, price);
        if (product == null)
            return BadRequest();

        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _service.DeleteProduct(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}