using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly DiyorMarketDbContext _context;

        private ICategoryRepository _categories;
        public ICategoryRepository Categories
        {
            get
            {
                _categories ??= new CategoryRepository(_context);

                return _categories;
            }
        }

        private IProductRepository _products;
        public IProductRepository Products
        {
            get
            {
                _products ??= new ProductRepository(_context);

                return _products;
            }
        }

        private IProductCategoryRepository _productCategories;
        public IProductCategoryRepository ProductCategories
        {
            get
            {
                _productCategories ??= new ProductCategoryRepository(_context);

                return _productCategories;
            }
        }

        private ICustomerRepository _customers;
        public ICustomerRepository Customers
        {
            get
            {
                _customers ??= new CustomerRepository(_context);

                return _customers;
            }
        }

        private ISaleRepository _sales;
        public ISaleRepository Sales
        {
            get
            {
                _sales ??= new SaleRepository(_context);

                return _sales;
            }
        }

        private ISaleItemRepository _saleItems;
        public ISaleItemRepository SaleItems
        {
            get
            {
                _saleItems ??= new SaleItemRepository(_context);

                return _saleItems;
            }
        }

        private ISupplierRepository _suppliers;
        public ISupplierRepository Suppliers
        {
            get
            {
                _suppliers ??= new SupplierRepository(_context);

                return _suppliers;
            }
        }

        private ISupplyRepository _supplies;
        public ISupplyRepository Supplies
        {
            get
            {
                _supplies ??= new SupplyRepository(_context);

                return _supplies;
            }
        }

        private ISupplyItemRepository _supplyItems;
        public ISupplyItemRepository SupplyItems
        {
            get
            {
                _supplyItems ??= new SupplyItemRepository(_context);

                return _supplyItems;
            }
        }

        public int SaveChanges() => _context.SaveChanges();

        public CommonRepository(DiyorMarketDbContext context)
        {
            _context = context;

            _categories = new CategoryRepository(context);
            _products = new ProductRepository(context);
            _productCategories = new ProductCategoryRepository(context);
            _customers = new CustomerRepository(context);
            _sales = new SaleRepository(context);
            _saleItems = new SaleItemRepository(context);
            _suppliers = new SupplierRepository(context);
            _supplies = new SupplyRepository(context);
            _supplyItems = new SupplyItemRepository(context);
        }
    }
}
