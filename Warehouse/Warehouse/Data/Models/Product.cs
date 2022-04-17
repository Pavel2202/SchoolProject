namespace Warehouse.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Warehouse.Data.Models.Enums;
    using static DataConstants;

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string ProductName { get; set; }

        [Required]
        public MeasurementUnit MeasurementUnit { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        [MaxLength(ProductSupplierMaxLength)]
        public string Supplier { get; set; }

        [Required]
        public string DateOfDelivery { get; set; }
    }
}
