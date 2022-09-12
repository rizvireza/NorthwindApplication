using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using northwind_backend.DTOS;
using northwind_backend.Repositories;

namespace northwind_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;        
        private readonly IMapper _mapper;
        private const int NUMBER_OF_OBJECSTS_PER_PAGE = 10;

        public CustomerController(IMapper mapper, ICustomerRepository customerRepository)
        {            
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        // GET: api/Customers
        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers(int page)
        {
            if (_customerRepository.IsCustomerNull())
            {
                return NotFound();
            }

            var customers = (await _customerRepository.GetAllCustomers())
                .Skip(NUMBER_OF_OBJECSTS_PER_PAGE * page)
                .Take(NUMBER_OF_OBJECSTS_PER_PAGE);
                            
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }

        // GET: api/Count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetCount()
        {
            if (_customerRepository.IsCustomerNull())
            {
                return NotFound();
            }

            return (await _customerRepository.GetAllCustomers()).Count();            
        }

        // GET: api/Customers
        [HttpGet("customerorders")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomerOrders(int page)
        {
            if (_customerRepository.IsCustomerNull())
            {
                return NotFound();
            }

            var customers = (await _customerRepository.GetAllCustomerOrders())                
                .Skip(NUMBER_OF_OBJECSTS_PER_PAGE * page)
                .Take(NUMBER_OF_OBJECSTS_PER_PAGE);

            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDtos);
        }

        // GET: api/Customers
        [HttpGet("customerorderscount")]
        public async Task<ActionResult<int>> GetCustomerOrdersCount()
        {
            if (_customerRepository.IsCustomerNull())
            {
                return NotFound();
            }

            var count = (await _customerRepository.GetAllCustomerOrders()).Count();                
            
            return Ok(count);
        }
    }
}
