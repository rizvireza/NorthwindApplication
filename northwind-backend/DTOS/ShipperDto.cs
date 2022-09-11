using northwind_backend.Models;

namespace northwind_backend.DTOS
{
    public class ShipperDto
    {
        public ShipperDto()
        {           
        }

        public int ShipperId { get; set; }
        public string CompanyName { get; set; } = null!;
        public string? Phone { get; set; }        
    }
}
