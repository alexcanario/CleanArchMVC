using CleanArchMvc.App.Dtos;
using CleanArchMvc.App.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoryController(ICategoryService service) : Controller
{
	[HttpGet("List")]
	public async Task<IActionResult> Index()
	{
		var categories = await service.GetAllAsync();
		return View(categories);
	}

    public IActionResult Details()
    {
        return Ok();
    }

    [HttpGet()]
    [Route("api/[controller]")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CategoryDto category)
    {
        if (ModelState.IsValid)
        {
            await service.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        return View();
    }

    [HttpGet()]
    public async Task<IActionResult> Edit(int? id)
    {
        if(id == null)
            return BadRequest();

        var category = await service.GetCategoryByIdAsync(id.Value);
        if(category == null) 
            return NotFound();

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDto category)
    {
        if (category == null) return BadRequest();
        
        await service.UpdateAsync(category);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete()
    {
        return Ok();
    }
}