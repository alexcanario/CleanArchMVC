using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMVC.Infra.Data.Repositories;

public class CategoryRepository(AppDbContext context) 
    : ICategoryRepository
{
    public async Task<IEnumerable<Category?>> GetAllAsync()
    {
        return await context.Categories.ToListAsync();
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await context.Categories.FindAsync(id);
    }

    public async Task<Category> CreateAsync(Category category)
    {
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return category;
    }

    public async Task UpdateAsync(Category category)
    {
        var categoryToUpdate = await GetByIdAsync(category.Id);
        if (categoryToUpdate is null)
        {
            return;
        }

        categoryToUpdate.Update(category.Name);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var categoryToDelete = await GetByIdAsync(id);
        if (categoryToDelete is null)
        {
            return;
        }

        context.Categories.Remove(categoryToDelete);
        await context.SaveChangesAsync();
    }
}