using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using northwind_backend.DTOS;
using northwind_backend.Models;

namespace northwind_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly IMapper _mapper;
        private const int NUMBER_OF_OBJECSTS_PER_PAGE = 10;

        public CustomerController(NorthwindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers(int page)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }

            var customers = (await _context.Customers.ToListAsync())
                .Skip(NUMBER_OF_OBJECSTS_PER_PAGE * page)
                .Take(NUMBER_OF_OBJECSTS_PER_PAGE);
                            
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }

        // GET: api/Count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount()
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }

            var count = (await _context.Customers.ToListAsync()).Count();


            return count;
        }

        // GET: api/Customers
        [HttpGet("customerorders")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomerOrders(int page)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }

            var customers = (await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ThenInclude(p => p.Category)
                .ToListAsync())                
                .Skip(NUMBER_OF_OBJECSTS_PER_PAGE * page)
                .Take(NUMBER_OF_OBJECSTS_PER_PAGE);

            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }

        // GET: api/Customers
        [HttpGet("customerorderscount")]
        public async Task<ActionResult<int>> GetCustomerOrdersCount()
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }

            var count = (await _context.Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ThenInclude(p => p.Category)
                .ToListAsync()).Count();                
            
            return Ok(count);
        }
    }
}
