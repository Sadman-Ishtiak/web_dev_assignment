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
    [Bind("Name,Type,Description,Price,HasSupport,HasCustomization,PurchaseLink,MinimumHardwareRequirements,RecommendedHardwareRequirements,SoftwareRequirements")] Product product,
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
        ViewBag.FeaturesString = string.Join(";", item.Features ?? new List<string>());
        return View(item);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Name,Type,Description,Price,HasSupport,HasCustomization,PurchaseLink,MinimumHardwareRequirements,RecommendedHardwareRequirements,SoftwareRequirements")] Product updatedProduct,
        string featuresString)
    {
        if (ModelState.IsValid)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Update the properties
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Type = updatedProduct.Type;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.HasSupport = updatedProduct.HasSupport;
            existingProduct.HasCustomization = updatedProduct.HasCustomization;
            existingProduct.Features = string.IsNullOrEmpty(featuresString)
                ? new List<string>()
                : featuresString.Split(';', StringSplitOptions.RemoveEmptyEntries)
                                .Select(f => f.Trim())
                                .ToList();
            existingProduct.MinimumHardwareRequirements = updatedProduct.MinimumHardwareRequirements;
            existingProduct.RecommendedHardwareRequirements = updatedProduct.RecommendedHardwareRequirements;
            existingProduct.SoftwareRequirements = updatedProduct.SoftwareRequirements;

            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }

        ViewBag.FeaturesString = featuresString;
        return View(updatedProduct);
    }

    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> List() {
        // Example to add a product to the list. Remove in production.
        var items = await _context.Products.ToListAsync();
        return View(items);
    }
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id) {
        var item = await _context.Products.FindAsync(id);
        if (item == null)
            return NotFound();
        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Admin")]
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