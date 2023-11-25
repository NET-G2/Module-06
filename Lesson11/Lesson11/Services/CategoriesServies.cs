using Lesson11.Data;
using Lesson11.Models;

namespace Lesson11.Services
{
    public class CategoriesServies
    {
        private readonly DiyorMarketDbContext _dbContext;
        public CategoriesServies(DiyorMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Category> GetCategories() => _dbContext.Categories.ToList();
        public void CreateCategories(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }
        public Category GetCategoriesById(int id) => _dbContext.Categories.Find(id);
        public void UpdateCategories(Category updateCategory)
        {
            var category = _dbContext.Categories.Find(updateCategory.Id);
            if (category != null)
            {
                category.Name = updateCategory.Name;
                _dbContext.SaveChanges();
            }
        }
        public void DeleteCategories(int id)
        {
            var categoies = _dbContext.Categories.Find(id);
            if (categoies != null)
            {
                _dbContext.Categories.Remove(categoies);
                _dbContext.SaveChanges();
            }
        }
    }
}
