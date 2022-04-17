namespace Warehouse.Services.Products
{
    using Warehouse.Data.Models;
    using Warehouse.Models.Products;

    public interface IProductsService
    {
        IEnumerable<Product> All(AllProductsQueryModel query);

        void Add(ProductFormModel model);

        Product GetProduct(int id);

        ProductFormModel ConvertToProductFormModel(Product product);

        bool Edit(int id, ProductFormModel model);

        void Delete(Product product);

        int TotalProducts();
    }
}
