using OnlineStore.Models;

namespace OnlineStore.Interfaces.ProductInterfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetAllProducts();
        Product GetProduct(int id);
        bool CreateProduct(int categoryId, Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
}
