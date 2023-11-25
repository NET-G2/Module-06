using Lesson11.Data;
using Lesson11.Models;

public class ProductService
{
    private readonly DiyorMarketDbContext _dbContext;
    public ProductService(DiyorMarketDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Product> GetProducts() => _dbContext.Products.ToList();
    public void CreateProduct(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
    }
    public Product GetProductById(int id) => _dbContext.Products.Find(id);
    public void UpdateProduct(Product updatedProduct)
    {
        var product = _dbContext.Products.Find(updatedProduct.Id);
        if (product != null)
        {
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.SalePrice = updatedProduct.SalePrice;
            product.SupplyPrice = updatedProduct.SupplyPrice;

            _dbContext.SaveChanges();
        }
    }
    public void DeleteProduct(int id)
    {
        var product = _dbContext.Products.Find(id);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
