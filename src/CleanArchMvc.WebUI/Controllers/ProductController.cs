using AutoMapper;

using CleanArchMvc.App.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductController(IProductService service, IMapper mapper) : Controller
{
    // GET: ProductController
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var products = await service.GetAllAsync();
            return products.Any() ? View(products) : NotFound();
        }
        catch
        {
            return BadRequest();
        }
    }

    // GET: ProductController/Details/5
    [HttpGet]
    public IActionResult Details(int id)
    {
        return BadRequest();
    }

    // GET: ProductController/Create
    public IActionResult Create()
    {
        return BadRequest();
    }

    // POST: ProductController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return BadRequest();
        }
    }

    // GET: ProductController/Edit/5
    [HttpGet]
    public IActionResult Edit(int id)
    {
        return BadRequest();
    }

    // POST: ProductController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return BadRequest();
        }
    }

    // GET: ProductController/Delete/5
    [HttpGet]
    public IActionResult Delete(int id)
    {
        return BadRequest();
    }

    // POST: ProductController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return BadRequest();
        }
    }
}