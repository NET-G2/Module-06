using Supermarket.Domain.Entities;
using Supermarket.Domain.Interfaces.Repositories;
using Supermarket.Infrastructure.Persistence;

namespace Supermarket.Infrastructure.Repositories
{
    internal class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(SupermarketDbContext context)
            : base(context) { }
    }
}
