using AutoMapper;

using CleanArchMvc.App.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoryController(ICategoryService service) : Controller
{
	[HttpGet("Details")]
	public async Task<IActionResult> Index()
	{
		var categories = await service.GetAllAsync();
		return View(categories);
	}

    public IActionResult Details()
    {
        return Ok();
    }

    public IActionResult Create()
    {
        return Ok();
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