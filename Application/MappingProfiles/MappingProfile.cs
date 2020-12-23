using AutoMapper;
using Domain;
using Domain.DTOs;

namespace Application.Employee
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDetails, EmployeeDetailsDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Office, OfficeDto>();
            CreateMap<Documents, DocumentsDto>();
            CreateMap<AppUser, AppUserDto>();
            CreateMap<Company, CompanyDto>();
            CreateMap<Leaves, LeavesDto>();
            CreateMap<Leaves, LeavesDto>();
            CreateMap<LeaveRequest, LeaveRequestDto>();
            CreateMap<Events, EventsDto>();

        }
    }
}