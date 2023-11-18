namespace DiyorMarket.Domain.Interfaces.Repositories
{
    public interface ICommonRepository
    {
        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IProductCategoryRepository ProductCategories { get; }
        public ICustomerRepository Customers { get; }
        public ISaleRepository Sales { get; }
        public ISaleItemRepository SaleItems { get; }
        public ISupplierRepository Suppliers { get; }
        public ISupplyRepository Supplies { get; }
        public ISupplyItemRepository SupplyItems { get; }

        public int SaveChanges();

    }
}
