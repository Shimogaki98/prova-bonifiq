using ProvaPub.Models;

namespace ProvaPub.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer?> FindAsync(int customerId);
        Task<int> GetOrdersInThisMonthAsync(int customerId, DateTime baseDate);
        Task<int> HaveBoughtBeforeAsync(int customerId);
    }
}
