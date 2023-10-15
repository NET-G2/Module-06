using Lesson01.Models;

namespace Lesson01.Services
{
    public class CategoryService
    {
        private static List<Category> _categories = new List<Category>();
        public CategoryService()
        {
            PopulateData();
        }

        public IEnumerable<Category> GetCategories() => _categories;

        public Category? FindById(int id) => _categories.FirstOrDefault(x => x.Id == id);

        public void Create(Category category) => _categories.Add(category);

        public void Update(Category categoryToUpdate)
        {
            var category = FindById(categoryToUpdate.Id);

            if (category != null)
            {
                category.Name = categoryToUpdate.Name;
                category.NumberOfProducts = categoryToUpdate.NumberOfProducts;
            }
        }

        public void Delete(int id)
        {
            var category = FindById(id);
            _categories.Remove(category);
        }

        private void PopulateData()
        {
            if (_categories.Count > 0)
            {
                return;
            }

            _categories.Add(new Category()
            {
                Id = 1,
                Name = "Drinks",
                NumberOfProducts = 20,
            });

            _categories.Add(new Category()
            {
                Id = 2,
                Name = "Sweets",
                NumberOfProducts = 150,
            });

            _categories.Add(new Category()
            {
                Id = 3,
                Name = "Fruits",
                NumberOfProducts = 67,
            });

            _categories.Add(new Category()
            {
                Id = 4,
                Name = "Vegatables",
                NumberOfProducts = 24,
            });

            _categories.Add(new Category()
            {
                Id = 5,
                Name = "Milks",
                NumberOfProducts = 32,
            });
        }
    }
}
