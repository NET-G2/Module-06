﻿using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Interfaces.Repositories
{
    public interface ISupplyItemRepository : IRepositoryBase<SupplyItem>
    {
        public IEnumerable<SupplyItem> FindBySupplyId(int supplyId);
    }
}
