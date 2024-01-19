using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RumProject.API.Models.Domain;
using RumProject.API.Models.DTO;
using RumProject.API.Repositories;

namespace RumProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistilleryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDistilleryRepository _distilleryRepository;

        public DistilleryController(IMapper mapper, IDistilleryRepository distilleryRepository)
        {
            _mapper = mapper;
            _distilleryRepository = distilleryRepository;
        }

        // GET ALL DISTILLERIES 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From DB
            var distilleriesDomain = await _distilleryRepository.GetAllAsync();

            // Map Domain Models to DTO
            return Ok(_mapper.Map<List<DistilleryDTO>>(distilleriesDomain));
        }

        // GET Single DISTILLERY 
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var distilleryDomainModel = await _distilleryRepository.GetByIdAsync(id);
            if(distilleryDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(_mapper.Map<DistilleryDTO>(distilleryDomainModel));

        }


        // CREATE DISTILLERY
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddDistilleryRequestDto addDistilleryRequestDto)
        {
            // Map DTO to Domain Model
            var distilleriesDomain = _mapper.Map<Distillery>(addDistilleryRequestDto);

            await _distilleryRepository.CreateAsync(distilleriesDomain);

            // Map Domain Model to DTO
            return Ok(_mapper.Map<DistilleryDTO>(distilleriesDomain));

        }

        // UPDATE DISTILLERY
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, UpdateDistilleryRequestDto updateDistilleryRequestDto)
        {
            // Map DTO to Domain Model
            var distilleryDomainModel = _mapper.Map<Distillery>(updateDistilleryRequestDto);

            distilleryDomainModel = await _distilleryRepository.UpdateAsync(id, distilleryDomainModel);
            if(distilleryDomainModel == null)
            {
                return NotFound();

            }
            // Map Domain Model to DTO
            return Ok(_mapper.Map<DistilleryDTO>(distilleryDomainModel)) ;
        }

        // DELETE DISTILLERY
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var deletedDistilleryDomainModel = _distilleryRepository.DeleteAsync(id);
            if(deletedDistilleryDomainModel == null)
            {
                return NotFound();
            }
            
            // Map Domain Model to DTO
            return Ok(_mapper.Map<DistilleryDTO>(deletedDistilleryDomainModel));
        }

        
    }
}
