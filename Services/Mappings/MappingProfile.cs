using AutoMapper;
using Domain.Models;
using Services.DTOs.Account;
using Services.DTOs.City;
using Services.DTOs.Country;
using Services.DTOs.Employee;


namespace Services.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeCreateDto, Employee>();
            CreateMap<EmployeeUpdateDto, Employee>();

            CreateMap<RegisterDto, AppUser>();

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryUpdateDto, Country>();

            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CityCreateDto, City>();
            CreateMap<CityUpdateDto, City>();
        }
    }
}
