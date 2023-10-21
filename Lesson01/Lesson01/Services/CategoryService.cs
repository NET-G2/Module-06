using Lesson01.Models;
using System.IO;
using System.Text.Json;

namespace Lesson01.Services
{
    public class CategoryService
    {
        public static string path = "D:\\github darslar\\Module-06\\Lesson01\\Lesson01\\Data\\categoriesData.json";
        public static List<Category> _categories = CategoriesDiserialize();
        

        public IEnumerable<Category> GetCategories() => _categories;

        public Category? FindById(int id) => _categories.FirstOrDefault(x => x.Id == id);

        public void Create(Category category)
        {
            _categories.Add(category);
            CategoriesSerialization(_categories);
        }

        public void Update(Category categoryToUpdate)
        {
            var category = FindById(categoryToUpdate.Id);

            if (category != null)
            {
                category.Name = categoryToUpdate.Name;
                category.NumberOfProducts = categoryToUpdate.NumberOfProducts;
                CategoriesSerialization(_categories);
            }
        }

        public void Delete(int id)
        {
            var category = FindById(id);
            if (category != null)
            {
                _categories.Remove(category);
                CategoriesSerialization(_categories);
            }
        }


        public static List<Category> CategoriesDiserialize()
        {
            var categories = new List<Category>();

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                categories = JsonSerializer.Deserialize<List<Category>>(json);

                return categories ?? new List<Category>();
            }

            return categories;
        }

        private void CategoriesSerialization(List<Category> category)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();

                string json = JsonSerializer.Serialize(category, new JsonSerializerOptions { WriteIndented = true });

                File.WriteAllText(path, json);
            }

            else
            {
                string json = JsonSerializer.Serialize(category, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(path, json);
            }
        }
    }
}
