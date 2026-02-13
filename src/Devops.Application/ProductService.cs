using Devops.Domain;

namespace Devops.Application;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetAllProductsAsync()
        => await _repository.GetAllAsync();

    public async Task<Product?> GetProductByIdAsync(Guid id)
        => await _repository.GetByIdAsync(id);

    public async Task<Product?> CreateProductAsync(string name, decimal price, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name) || price <= 0)
            return null;

        return await _repository.CreateAsync(new Product
        {
            Name = name,
            Price = price,
            CategoryId = categoryId
        });
    }

    public async Task<bool> DeleteProductAsync(Guid id)
        => await _repository.DeleteAsync(id);
}