using AutoMapper;
using Lab4DbAPI.Models.DTO;
using Lab4DbAPI.Models;

namespace Lab4DbAPI.AutoMapper
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<SupplierDTO, Supplier>();
            CreateMap<SupplierCreateDTO, SupplierDTO>();
            CreateMap<SupplierDTO, SupplierCreateDTO>();
        }
    }
}
