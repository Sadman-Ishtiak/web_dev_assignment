using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using web_dev_assignment.Models;
using web_dev_assignment.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Features;


namespace web_dev_assignment.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context) {
        _context = context;
    }

    public async Task<IActionResult> Index() {
        // Example to add a product to the list. Remove in production.
        var items = await _context.Products.ToListAsync();
        return View(items);
    }

    [Authorize(Roles = "Admin")] 
    public IActionResult Create() {
        return View();
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(
        [Bind("Name,Type,Description,Price,HasSupport,HasCustomization")] Product product,
        string featuresString)
    {
        if (ModelState.IsValid)
        {
            product.Features = string.IsNullOrEmpty(featuresString)
                ? new List<string>()
                : featuresString.Split(';', StringSplitOptions.RemoveEmptyEntries)
                                .Select(f => f.Trim())
                                .ToList();

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        ViewBag.FeaturesString = featuresString;
        return View(product);
    }
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> Edit(int id) {
        Console.WriteLine("id = ", id);
        var item = await _context.Products.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> Edit(int id, [Bind("Name", "Type", "Description", "Price", "featuresString", "HasSupport", "HasCustomization")] Product product) {
        if(ModelState.IsValid) {
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
        return View(product);
    }
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> List() {
        // Example to add a product to the list. Remove in production.
        var items = await _context.Products.ToListAsync();
        return View(items);
    }
    [HttpPost]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> Delete(int id) {
        var item = await _context.Products.FindAsync(id);
        return View(item);
    }
    [Authorize(Roles = "Admin")]
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _context.Products.FindAsync(id);
        if(item != null)
        {
            _context.Products.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index");
    }
}