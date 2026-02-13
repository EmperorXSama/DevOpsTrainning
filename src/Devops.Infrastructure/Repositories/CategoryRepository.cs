// src/Devops.Infrastructure/Repositories/CategoryRepository.cs

using Devops.Application;
using Devops.Domain;

using Devops.Infrastructure.Presestence;
using Microsoft.EntityFrameworkCore;

namespace Devops.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync()
        => await _context.Categories.ToListAsync();

    public async Task<Category?> GetByIdAsync(Guid id)
        => await _context.Categories
            .Include(c => c.Products)
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Category> CreateAsync(Category category)
    {
        category.Id = Guid.NewGuid();
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return category;
    }
}