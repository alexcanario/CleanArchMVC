using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await context.Products.AsNoTracking().ToListAsync();
    }

    public async Task<Product> GetByIdAsync(int? id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<Product> GetByNameAsync(string name)
    {
        return await context.Products.FirstOrDefaultAsync(_ => _.Name.Contains(name));
    }

    public async Task CreateAsync(Product entity)
    {
        await context.Products.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product entity)
    {
        try
        {
            context.Products.Update(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        var category = await context.Products.FindAsync(id);

        if (category is null) return;

        context.Products.Remove(category);
        await context.SaveChangesAsync();
    }

    public async Task<Product> GetProductWithCategoryByIdAsync(int id)
    {
        return await context.Products.Include(_ => _.Category).SingleOrDefaultAsync(_ => _.Id == id);
    }
}