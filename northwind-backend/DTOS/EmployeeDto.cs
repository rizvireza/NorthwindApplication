using northwind_backend.Models;

namespace northwind_backend.DTOS
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {            
            Territories = new HashSet<Territory>();
        }
        
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? HomePhone { get; set; }
        public string? Extension { get; set; }        
        //public string? Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string? PhotoPath { get; set; }

        public virtual EmployeeDto? ReportsToNavigation { get; set; }        

        public virtual ICollection<Territory> Territories { get; set; }
    }
}
