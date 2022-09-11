using AutoMapper;
using northwind_backend.Models;

namespace northwind_backend.DTOS
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Order, OrderDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<Shipper, ShipperDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
