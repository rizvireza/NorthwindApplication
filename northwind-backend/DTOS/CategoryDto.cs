using northwind_backend.Models;

namespace northwind_backend.DTOS
{
    public class CategoryDto
    {
        public CategoryDto()
        {            
        }
        
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }        

        
    }
}
