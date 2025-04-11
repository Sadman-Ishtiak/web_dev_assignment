using Microsoft.AspNetCore.Identity;

namespace web_dev_assignment.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Optional: Add user-specific info here

        public Cart Cart { get; set; }  // 👈 Navigation to their Cart
    }
}
