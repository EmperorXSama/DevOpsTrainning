using Devops.API.Controllers;
using Devops.Application;
using Microsoft.AspNetCore.Mvc;

namespace Devops.Tests;

public class ProductControllerTests
{
    [Fact]
    public void GetAll_ReturnsOk()
    {
        var controller = new ProductController(new ProductService());

        var result = controller.GetAll();

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetById_ValidId_ReturnsOk()
    {
        var service = new ProductService();
        var controller = new ProductController(service);
        var product = service.GetAllProducts().First();

        var result = controller.GetById(product.Id);

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetById_InvalidId_ReturnsNotFound()
    {
        var controller = new ProductController(new ProductService());

        var result = controller.GetById(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Create_InvalidData_ReturnsBadRequest()
    {
        var controller = new ProductController(new ProductService());

        var result = controller.Create("", -1);

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public void Delete_InvalidId_ReturnsNotFound()
    {
        var controller = new ProductController(new ProductService());

        var result = controller.Delete(Guid.NewGuid());

        Assert.IsType<NotFoundResult>(result);
    }
}