using Devops.Domain;

namespace Devops.Application;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(Guid id);
    Task<Product> CreateAsync(Product product);
    Task<bool> DeleteAsync(Guid id);
}