using northwind_backend.Models;

namespace northwind_backend.DTOS
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderDetails = new HashSet<OrderDetailDto>();
        }

        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public string? ShipRegion { get; set; }
        public string? ShipPostalCode { get; set; }
        public string? ShipCountry { get; set; }

        //public virtual CustomerDto? Customer { get; set; }
        public virtual EmployeeDto? Employee { get; set; }
        public virtual ShipperDto? ShipViaNavigation { get; set; }
        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}
