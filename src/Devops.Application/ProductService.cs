using Devops.Domain;

namespace Devops.Application;

public class ProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        _products = Enumerable.Range(5, 20)
            .Select(i => new Product
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Name = $"Product {i}",
                Price = i
            }).ToList();
    }

    public List<Product> GetAllProducts()
        => _products;

    public Product? GetProductById(Guid id)
        => _products.FirstOrDefault(p => p.Id == id);

    public Product? CreateProduct(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name) || price <= 0)
            return null;

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price,
            CreatedAt = DateTime.UtcNow
        };

        _products.Add(product);
        return product;
    }

    public bool DeleteProduct(Guid id)
    {
        var product = GetProductById(id);
        if (product == null)
            return false;

        _products.Remove(product);
        return true;
    }
}