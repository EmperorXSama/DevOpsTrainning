using Devops.Application;

namespace Devops.Tests;

public class ProductServiceTests
{
    [Fact]
    public void GetAllProducts_Returns20Products()
    {
        var service = new ProductService();
        var result = service.GetAllProducts();

        Assert.NotNull(result);
        Assert.Equal(20, result.Count);
    }

    [Fact]
    public void GetProductById_ValidId_ReturnsProduct()
    {
        var service = new ProductService();
        var product = service.GetAllProducts().First();

        var result = service.GetProductById(product.Id);

        Assert.NotNull(result);
        Assert.Equal(product.Id, result.Id);
    }

    [Fact]
    public void GetProductById_InvalidId_ReturnsNull()
    {
        var service = new ProductService();

        var result = service.GetProductById(Guid.NewGuid());

        Assert.Null(result);
    }

    [Fact]
    public void CreateProduct_ValidData_AddsProduct()
    {
        var service = new ProductService();

        var result = service.CreateProduct("New Product", 100);

        Assert.NotNull(result);
        Assert.Equal("New Product", result.Name);
        Assert.Equal(21, service.GetAllProducts().Count);
    }

    [Fact]
    public void CreateProduct_InvalidData_ReturnsNull()
    {
        var service = new ProductService();

        var result = service.CreateProduct("", -5);

        Assert.Null(result);
    }

    [Fact]
    public void DeleteProduct_ValidId_RemovesProduct()
    {
        var service = new ProductService();
        var product = service.GetAllProducts().First();

        var result = service.DeleteProduct(product.Id);

        Assert.True(result);
        Assert.Equal(19, service.GetAllProducts().Count);
    }

    [Fact]
    public void DeleteProduct_InvalidId_ReturnsFalse()
    {
        var service = new ProductService();

        var result = service.DeleteProduct(Guid.NewGuid());

        Assert.False(result);
    }
}