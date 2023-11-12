﻿using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        public Customer FindByPhone(string phone);
    }
}
