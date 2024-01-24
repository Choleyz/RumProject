using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RumProject.API.CustomActionFilters;
using RumProject.API.Models.Domain;
using RumProject.API.Models.DTO;
using RumProject.API.Repositories;

namespace RumProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlcoholController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAlcoholRepository _alcoholRepository;

        public AlcoholController(IMapper mapper, IAlcoholRepository alcoholRepository)
        {
            _mapper = mapper;
            _alcoholRepository = alcoholRepository;
        }

        // GET ALL ALCOHOLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alcoholDomainModel = await _alcoholRepository.GetAllAsync();
            // Map Domain Model to DTO

            return Ok(_mapper.Map<List<AlcoholDTO>>(alcoholDomainModel));
        }

        // GET SINGLE ALCOHOL
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var alcoholDomainModel = await _alcoholRepository.GetByIdAsync(id);

            if (alcoholDomainModel == null)
            {
                return NotFound();
            }
            // Map Domain Model to DTO
            return Ok(_mapper.Map<AlcoholDTO>(alcoholDomainModel));
        }

        // CREATE ALCOHOL
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddAlcoholRequestDto addAlcoholRequestDto)
        {
            // Map DTO to Domain Model
            var alcoholDomainModel = _mapper.Map<Alcohol>(addAlcoholRequestDto);

            await _alcoholRepository.CreateAsync(alcoholDomainModel);


            // Map Domain Model to DTO
            return Ok(_mapper.Map<AlcoholDTO>(alcoholDomainModel));
        }

        // UPDATE ALCOHOL
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateAlcoholRequestDto updateAlcoholRequestDto)
        {
            // Map Dto to Domain Model
            var alcoholDomainModel = _mapper.Map<Alcohol>(updateAlcoholRequestDto);

            alcoholDomainModel = await _alcoholRepository.UpdateAsync(id, alcoholDomainModel);

            if (alcoholDomainModel == null)
            { 
                return NotFound(); 
            }

            // Map Domain Model to DTO
            return Ok(_mapper.Map<AlcoholDTO>(alcoholDomainModel));

        }

        // DELETE ALCOHOL
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deletedAlcoholDomainModel = await _alcoholRepository.DeleteAsync(id);

            if(deletedAlcoholDomainModel == null)
            { return NotFound(); }

            // Map Domain Model to DTO
            return Ok(_mapper.Map<AlcoholDTO>(deletedAlcoholDomainModel));

        }

    }
}
