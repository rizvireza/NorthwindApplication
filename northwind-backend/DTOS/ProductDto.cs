using northwind_backend.Models;

namespace northwind_backend.DTOS
{
    public class ProductDto
    {
        public ProductDto()
        {            
        }
        
        public string ProductName { get; set; } = null!;
        public string? QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public virtual CategoryDto? Category { get; set; }
        public virtual Supplier? Supplier { get; set; }        
    }
}
