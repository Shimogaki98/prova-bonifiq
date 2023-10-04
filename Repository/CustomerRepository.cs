using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;

namespace ProvaPub.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TestDbContext _dbContext;

        public CustomerRepository(TestDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer?> FindAsync(int customerId)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(s => s.Id == customerId); ;
        }

        public async Task<int> GetOrdersInThisMonthAsync(int customerId, DateTime baseDate)
        {
            return await _dbContext.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
        }

        public async Task<int> HaveBoughtBeforeAsync(int customerId)
        {
            return await _dbContext.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
        }


    }
}
