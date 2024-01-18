using AutoMapper;
using RumProject.API.Models.Domain;
using RumProject.API.Models.DTO;

namespace RumProject.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap <Provenance, ProvenanceDTO>().ReverseMap();
            CreateMap<AddProvenanceRequestDto, Provenance>().ReverseMap();
            CreateMap<UpdateProvenanceRequestDto, Provenance>().ReverseMap();

        }
    }
}
