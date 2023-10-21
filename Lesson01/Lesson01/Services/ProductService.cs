using Lesson01.Models;
using Newtonsoft.Json;

public class ProductService
{
    private List<Product> _products = new List<Product>();

    public ProductService()
    {
        LoadDataFromJson();
    }

    public IEnumerable<Product> GetProducts() => _products;

    public void Create(Product product)
    {
        _products.Add(product);
        SaveDataToJson();
    }

    public Product FindById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void Update(Product productToUpdate)
    {
        var product = FindById(productToUpdate.Id);
        if (product != null)
        {
            product.Name = productToUpdate.Name;
            product.Description = productToUpdate.Description;
            product.Price = productToUpdate.Price;
            SaveDataToJson();
        }
    }

    public void Delete(int id)
    {
        var product = FindById(id);
        if (product != null)
        {
            _products.Remove(product);
            SaveDataToJson();
        }
    }

    private void SaveDataToJson()
    {
        string json = JsonConvert.SerializeObject(_products, Formatting.Indented);
        File.WriteAllText("products.json", json);
    }

    private void LoadDataFromJson()
    {
        if (File.Exists("products.json"))
        {
            string json = File.ReadAllText("products.json");
            _products = JsonConvert.DeserializeObject<List<Product>>(json);
        }
    }
}
