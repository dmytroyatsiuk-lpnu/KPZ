using AutoMapper;
using Lab4DbAPI.Models;
using Lab4DbAPI.Models.DTO;

namespace Lab4DbAPI.AutoMapper
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile()
        {
            CreateMap<Material, MaterialDTO>();
            CreateMap<MaterialDTO, Material>();
            CreateMap<MaterialCreateDTO, MaterialDTO>();
            CreateMap<MaterialDTO, MaterialCreateDTO>();
        }
    }
}
