using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using web_dev_assignment.Models;

namespace web_dev_assignment.Controllers;

public class AdminController : Controller {
    [Authorize(Roles = "Admin")] 
    public IActionResult Index() {
        return View();
    }
}