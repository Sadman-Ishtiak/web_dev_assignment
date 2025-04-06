using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using web_dev_assignment.Models;


namespace web_dev_assignment.Controllers;

public class ProductController : Controller
{
    private List<Product> _products = new List<Product>(); // Initialize the list

    public IActionResult Index()
    {
        // Example to add a product to the list. Remove in production.
        var product = new Product { Name = "Linux", Type = "Desktop", Description = "The Linux Operating System" };
        if(_products.Count == 0)
            _products.Add(product);

        return View(_products); // Return the list of products
    }
    
    [Authorize(Roles = "Admin")] 
    public IActionResult Create()
    {
        return View();
    }
}