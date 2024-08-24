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

    public IActionResult Edit()
    {
        return Ok();
    }

    public IActionResult Delete()
    {
        return Ok();
    }
}