namespace Warehouse.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Warehouse.Models.Products;
    using Warehouse.Services.Products;

    using static WebConstants;

    public class ProductsController : Controller
    {
        private readonly IProductsService service;

        public ProductsController(IProductsService service)
        {
            this.service = service;
        }

        public IActionResult All([FromQuery] AllProductsQueryModel query)
        {
            var products = service.All(query);

            var model = new AllProductsQueryModel()
            {
                SearchTerm = query.SearchTerm,
                CurrentPage = query.CurrentPage,
                TotalProducts = service.TotalProducts()
            };

            model.Products = products;

            return this.View(model);
        }

        [Authorize]
        public IActionResult Add()
            => this.View(new ProductFormModel());

        [HttpPost]
        [Authorize]
        public IActionResult Add(ProductFormModel product)
        {
            if (!ModelState.IsValid)
            {
                return this.View(product);
            }

            service.Add(product);

            TempData[GlobalMessageKey] = "You successfully added product!";

            return this.RedirectToAction("All", "Products");
        }

        public IActionResult Details(int id)
        {
            var product = service.GetProduct(id);

            return this.View(product);
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var product = service.GetProduct(id);

            var model = service.ConvertToProductFormModel(product);

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var edited = service.Edit(id, model);

            if (!edited)
            {
                return BadRequest();
            }

            TempData[GlobalMessageKey] = "You successfully edited product!";

            return this.RedirectToAction("All", "Products");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var product = service.GetProduct(id);

            service.Delete(product);

            TempData[GlobalMessageKey] = "You successfully deleted product!";

            return this.RedirectToAction("All", "Products");
        }
    }
}
