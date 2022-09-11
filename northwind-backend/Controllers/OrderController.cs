using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using northwind_backend.DTOS;
using northwind_backend.Models;

namespace northwind_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly IMapper _mapper;
        private const int NUMBER_OF_OBJECSTS_PER_PAGE = 10;

        public OrderController(NorthwindContext context, IMapper mapper)
        {
            _context = context;
            _mapper = _mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet("orders")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(int page)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }

            var orders = (await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.Category)
                .Include(o => o.Employee)
                .Include(o => o.Customer)
                .Include(o => o.ShipViaNavigation).ToListAsync())
                .Skip(NUMBER_OF_OBJECSTS_PER_PAGE * page)
                .Take(NUMBER_OF_OBJECSTS_PER_PAGE);

            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(orderDtos);            
        }

        // GET: api/count
        [HttpGet("count")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrderCount()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }

            var count = (await _context.Orders
                .Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .Include(o => o.Employee)
                .Include(o => o.Customer)
                .Include(o => o.ShipViaNavigation).ToListAsync()).Count();                
            
            return Ok(count);
        }


    }
}
