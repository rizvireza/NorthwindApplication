using northwind_backend.Models;

namespace northwind_backend.DTOS
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            Orders = new HashSet<OrderDto>();
            CustomerTypes = new HashSet<CustomerDemographic>();
        }
        
        public string CompanyName { get; set; } = null!;
        public string? ContactName { get; set; }
        public string? ContactTitle { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }
        public virtual ICollection<OrderDto> Orders { get; set; }
        public virtual ICollection<CustomerDemographic> CustomerTypes { get; set; }
    }
}
