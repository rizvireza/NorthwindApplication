using northwind_backend.Models;

namespace northwind_backend.DTOS
{
    public class OrderDetailDto
    {
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }        
        public virtual ProductDto Product { get; set; } = null!;
    }
}
