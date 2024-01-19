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
            CreateMap<Alcohol, AlcoholDTO>().ReverseMap();
            CreateMap<AddAlcoholRequestDto, Alcohol>().ReverseMap();
            CreateMap<UpdateAlcoholRequestDto, Alcohol>().ReverseMap();
            // Distillery
            CreateMap<Distillery, DistilleryDTO>().ReverseMap();
            CreateMap<AddDistilleryRequestDto, Distillery>().ReverseMap();
            CreateMap<UpdateDistilleryRequestDto, Distillery>().ReverseMap();


        }
    }
}
