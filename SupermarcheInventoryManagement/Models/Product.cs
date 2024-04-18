using System.ComponentModel.DataAnnotations;

namespace SupermarcheInventoryManagement.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        public string ProductName {  get; set; }
        [Required]
        public float Price {  get; set; }
        [Required]
        public int Quantity {  get; set; }
        [Required]
        public string Category { get; set; }
    }
}
