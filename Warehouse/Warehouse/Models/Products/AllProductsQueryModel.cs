namespace Warehouse.Models.Products
{
    using System.ComponentModel.DataAnnotations;
    using Warehouse.Data.Models;

    public class AllProductsQueryModel
    {
        public const int ProductsPerPage = 20;

        [Display(Name = "Search")]
        public string SearchTerm { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProducts { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
