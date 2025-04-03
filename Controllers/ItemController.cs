using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_dev_assignment.Models;

namespace web_dev_assignment.Controllers;
public class ItemController : Controller{
    public IActionResult Index() {
        var item = new Item() {ID = 1, Name = "Operating System", Description = "Linux is a powerful, open-source operating system known for its stability, security, and flexibility. It’s widely used in servers, embedded systems, and even desktop computing. With distributions like Ubuntu, Arch, and Debian, Linux caters to different user needs, from beginners to advanced programmers. Its command-line interface (CLI) is a favorite among developers and system administrators for automation and scripting. Plus, it’s a top choice for competitive programming due to its efficient resource management and compatibility with tools like GCC, Clang, and Vim. Do you use Linux for development or competitive programming?"};
        return View(item);
    }
    public IActionResult Details(int id) {
        return Content("id = " + id);
    }
}