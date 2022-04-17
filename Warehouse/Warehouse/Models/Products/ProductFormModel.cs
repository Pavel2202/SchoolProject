namespace Warehouse.Models.Products
{
    using System.ComponentModel.DataAnnotations;
    using Warehouse.Data.Models.Enums;
    using static Data.DataConstants;

    public class ProductFormModel
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string ProductName { get; set; }

        [Required]
        public string MeasurementUnit { get; set; }

        [Required]
        [Range(ProductQuantityMinValue, ProductQuantityMaxValue)]
        public int Quantity { get; set; }

        [Required]
        [Range(ProductUnitPriceMinValue, ProductUnitPriceMaxValue)]
        public decimal UnitPrice { get; set; }

        [Required]
        [StringLength(ProductSupplierMaxLength, MinimumLength = ProductSupplierMinLength)]
        public string Supplier { get; set; }

        [Required]
        [RegularExpression(@"\d{2}\/\d{2}\/\d{4}")]
        public string DateOfDelivery { get; set; }

        public IEnumerable<string> MeasurementUnits => GetMeasurementUnits();

        private IEnumerable<string> GetMeasurementUnits()
        {
            var values = Enum.GetValues(typeof(MeasurementUnit));

            var result = new List<string>();

            foreach (var unit in values)
            {
                result.Add(unit.ToString());
            }

            return result;
        }
    }
}
