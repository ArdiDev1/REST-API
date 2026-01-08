using AutoMapper;
using BackendApi.Dtos;
using BackendApi.Models;

namespace BackendApi.Data
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ComputerDto, Computer>();
            CreateMap<Computer, ComputerDto>();
        }
    }
}
