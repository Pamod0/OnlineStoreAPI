using OnlineStore.Models;

namespace OnlineStore.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        bool CreateCategory(Category category);
        bool Save();
    }
}
