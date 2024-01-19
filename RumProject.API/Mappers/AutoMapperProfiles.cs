using AutoMapper;
using RumProject.API.Models.Domain;
using RumProject.API.Models.DTO;

namespace RumProject.API.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //Provenance
            CreateMap <Provenance, ProvenanceDTO>().ReverseMap();
            CreateMap<AddProvenanceRequestDto, Provenance>().ReverseMap();
            CreateMap<UpdateProvenanceRequestDto, Provenance>().ReverseMap();
            //Alcohol
            CreateMap<AddAlcoholRequestDto, Alcohol>().ReverseMap();
            CreateMap<Alcohol, AlcoholDTO>().ReverseMap();
            // Distillery
            CreateMap<Distillery, DistilleryDTO>().ReverseMap();
            CreateMap<UpdateAlcoholRequestDto, Alcohol>().ReverseMap();
        }
    }
}
