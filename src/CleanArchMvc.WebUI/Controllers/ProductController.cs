using CleanArchMvc.App.Dtos;
using CleanArchMvc.App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchMvc.WebUI.Controllers;

[Authorize]
public class ProductController(IProductService serviceProduct, ICategoryService serviceCategory, IWebHostEnvironment env) : Controller
{
#region Index

    // GET: ProductController
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var products = await serviceProduct.GetAllAsync();
            return products.Any() ? View(products) : NotFound();
        }
        catch
        {
            return BadRequest();
        }
    }

#endregion

#region Create
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await serviceCategory.GetAllAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductDto product)
    {
        if (!ModelState.IsValid) return View(product);

        await serviceProduct.CreateAsync(product);

        return RedirectToAction(nameof(Index));
    }

#endregion Create

#region Edit
    // GET: ProductController/Edit/5
    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id is null) return BadRequest();
        
        var categories = await serviceCategory.GetAllAsync();
        var product = await serviceProduct.GetByIdAsync(id.Value);
        ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.CategoryId);

        return product == null ? NotFound() : View(product);
    }

    // POST: ProductController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductDto product)
    {
        if (!ModelState.IsValid) return View(nameof(Index));

        try
        {
            await serviceProduct.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return BadRequest();
        }
    }
    #endregion Edit

    #region Delete
    // GET: ProductController/Delete/5
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id is null) return BadRequest();

        var product = await serviceProduct.GetByIdAsync(id.Value);
        if(product == null) return NotFound();

        return View(product);
    }

    // POST: ProductController/Delete/5
    [HttpPost(), ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id is null) return BadRequest();
        try
        {
            await serviceProduct.DeleteAsync(id.Value);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return BadRequest();
        }
    }

    #endregion Delete

#region Details

    // GET: ProductController/Details/5
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if(id is null) return BadRequest();

        var product = await serviceProduct.GetProductCategoryByIdAsync(id.Value);
        if(product == null) return NotFound();

        var wwwrootPath = env.WebRootPath;
        var imagePath = Path.Combine(wwwrootPath, "images", product.Image);
        var imageExists = System.IO.File.Exists(imagePath);
        ViewBag.ImageExists = imageExists;

        return View(product);
    }

#endregion

}