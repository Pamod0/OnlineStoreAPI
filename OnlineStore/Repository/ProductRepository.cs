using OnlineStore.Interfaces.ProductInterfaces;
using OnlineStore.Models;
using PokemonReviewApp.Data;

namespace OnlineStore.Repository.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetAllProducts()
        {
            return _context.Products.OrderBy(p => p.Id).ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool CreateProduct(int categoryId, Product product)
        {
            var category = _context.ProductCategories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null)
                return false;

            product.Category = category;
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            _context.Add(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
