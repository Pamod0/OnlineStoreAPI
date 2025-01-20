using OnlineStore.Models;

namespace OnlineStore.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
        ICollection<Category> GetCategories();
        bool CategoryExists(int id);
        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
