using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using web_dev_assignment.Models;

namespace web_dev_assignment.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [Required]
        public string ProductQuantitiesJson { get; set; } = "{}";

        [NotMapped]
        public Dictionary<int, int> ProductQuantities
        {
            get => JsonSerializer.Deserialize<Dictionary<int, int>>(ProductQuantitiesJson) ?? new();
            set => ProductQuantitiesJson = JsonSerializer.Serialize(value);
        }
    }
}
