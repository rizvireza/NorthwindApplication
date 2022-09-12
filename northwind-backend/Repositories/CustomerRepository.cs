using Microsoft.EntityFrameworkCore;
using northwind_backend.Models;

namespace northwind_backend.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly NorthwindContext _context;
        public CustomerRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerOrders()
        {
            return await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ThenInclude(p => p.Category)
                .ToListAsync();
        }

        public bool IsCustomerNull()
        {
            if (_context.Customers == null)
                return true;

            return false;
        }
    }
}
