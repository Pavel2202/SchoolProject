namespace Warehouse.Services.Products
{
    using System.Collections.Generic;
    using Warehouse.Data;
    using Warehouse.Data.Models;
    using Warehouse.Data.Models.Enums;
    using Warehouse.Models.Products;

    public class ProductsService : IProductsService
    {
        private readonly WarehouseDbContext context;

        public ProductsService(WarehouseDbContext context)
        {
            this.context = context;
        }

        public void Add(ProductFormModel model)
        {
            var measurementUnit = Enum.Parse(typeof(MeasurementUnit), model.MeasurementUnit);

            var product = new Product()
            {
                ProductName = model.ProductName,
                MeasurementUnit = (MeasurementUnit)measurementUnit,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                Supplier = model.Supplier,
                DateOfDelivery = model.DateOfDelivery
            };

            context.Products.Add(product);

            context.SaveChanges();
        }

        public IEnumerable<Product> All(AllProductsQueryModel query)
        {
            var productsQuery = context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(query.SearchTerm))
            {
                productsQuery = productsQuery.Where(x => x.ProductName.ToLower().Contains(query.SearchTerm.ToLower()));
            }

            var products = productsQuery
                .Skip((query.CurrentPage - 1) * AllProductsQueryModel.ProductsPerPage)
                .Take(AllProductsQueryModel.ProductsPerPage)
                .Select(x => new Product()
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    MeasurementUnit = x.MeasurementUnit,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice,
                    Supplier = x.Supplier,
                    DateOfDelivery = x.DateOfDelivery
                })
                .ToList();

            return products;
        }

        public ProductFormModel ConvertToProductFormModel(Product product)
        {
            var model = new ProductFormModel()
            {
                ProductName = product.ProductName,
                MeasurementUnit = product.MeasurementUnit.ToString(),
                Quantity = product.Quantity,
                UnitPrice = product.UnitPrice,
                Supplier = product.Supplier,
                DateOfDelivery = product.DateOfDelivery
            };

            return model;
        }

        public void Delete(Product product)
        {
            context.Remove(product);

            context.SaveChanges();
        }

        public bool Edit(int id, ProductFormModel model)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == id);

            if (product is null)
            {
                return false;
            }

            var measurementUnit = Enum.Parse(typeof(MeasurementUnit), model.MeasurementUnit);

            product.ProductName = model.ProductName;
            product.MeasurementUnit = (MeasurementUnit)measurementUnit;
            product.Quantity = model.Quantity;
            product.UnitPrice = model.UnitPrice;
            product.Supplier = model.Supplier;
            product.DateOfDelivery = model.DateOfDelivery;

            context.SaveChanges();

            return true;
        }

        public Product GetProduct(int id)
            => context.Products.FirstOrDefault(x => x.Id == id);

        public int TotalProducts()
            => context.Products.Count();
    }
}
