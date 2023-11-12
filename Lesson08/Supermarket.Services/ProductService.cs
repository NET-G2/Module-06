using Supermarket.Domain.Entities;
using Supermarket.Domain.Exceptions;
using Supermarket.Domain.Interfaces.Repositories;
using Supermarket.Domain.Interfaces.Services;

namespace Supermarket.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _productRepository.FindAll();

            return products ?? Enumerable.Empty<Product>();
        }

        public Product GetById(int id)
        {
            var product = _productRepository.FindById(id);

            if (product is null)
            {
                throw new EntityNotFoundException($"Product with id: {id} does not exist", nameof(Product));
            }

            return product;
        }

        public Product Create(Product productToAdd)
        {
            ArgumentNullException.ThrowIfNull(nameof(productToAdd));

            var newProduct = _productRepository.Add(productToAdd);
            _productRepository.SaveChanges();

            return newProduct;
        }

        public void Update(Product productToUpdate)
        {
            ArgumentNullException.ThrowIfNull(nameof(productToUpdate));

            _productRepository.Update(productToUpdate);
            _productRepository.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _productRepository.FindById(id);

            if (product is null)
            {
                throw new EntityNotFoundException($"Product with id: {id} does not exist.", nameof(Product));
            }

            _productRepository.Delete(product);
            _productRepository.SaveChanges();
        }
    }
}
