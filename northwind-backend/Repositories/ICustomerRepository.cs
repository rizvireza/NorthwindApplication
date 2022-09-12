using northwind_backend.Models;

namespace northwind_backend.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<IEnumerable<Customer>> GetAllCustomerOrders();
        bool IsCustomerNull();
    }
}
