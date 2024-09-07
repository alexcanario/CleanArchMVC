using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
	public async Task<IEnumerable<Category>> GetAllAsync()
	{
		return await context.Categories.AsNoTracking().ToListAsync();
	}

	public async Task<Category> GetByIdAsync(int? id)
	{
		return await context.Categories.FindAsync(id);
	}

	public async Task<Category> GetByNameAsync(string name)
	{
		return await context.Categories.FirstOrDefaultAsync(_ => _.Name.Contains(name));
	}

	public async Task CreateAsync(Category entity)
	{
		context.Categories.Add(entity);
		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(Category entity)
	{
		context.Categories.Update(entity);
		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var category = await context.Categories.FindAsync(id);
		if (category == null) return;
		
		context.Categories.Remove(category);
		await context.SaveChangesAsync();
	}
}