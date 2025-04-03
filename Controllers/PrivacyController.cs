
using Microsoft.AspNetCore.Mvc;

namespace web_dev_assignment.Controllers{
    public class PrivacyController: Controller {
        public IActionResult Index() {
            return View();
        }
    }
}