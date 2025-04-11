using Microsoft.AspNetCore.Identity;

namespace web_dev_assignment.Models {
    public class ApplicationUser : IdentityUser {
        public Cart Cart { get; set; }
    }
}
