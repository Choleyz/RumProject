using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RumProject.API.Data;
using RumProject.API.Models.Domain;
using RumProject.API.Models.DTO;
using RumProject.API.Repositories;
using System.Collections.Generic;

namespace RumProject.API.Controllers
{
    // https://localhost:1234/api/provenances
    [Route("api/[controller]")]
    [ApiController]
    public class ProvenanceController : ControllerBase
    {
        private readonly RumProjectDBContext _dBContext;
        private readonly IProvenanceRepository _provenanceRepository;
        private readonly IMapper _mapper;

        public ProvenanceController(RumProjectDBContext dBContext, IProvenanceRepository provenanceRepository, IMapper mapper)
        {
            _dBContext = dBContext;
            _provenanceRepository = provenanceRepository;
            _mapper = mapper;
        }

        // GET ALL PROVENANCES 
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            // Get Data From DB
            var provenancesDomain = await _provenanceRepository.GetAllAsync();

            // Map Domain Models to DTO
            var provenancesDto = _mapper.Map<List<ProvenanceDTO>>(provenancesDomain);

            return Ok(provenancesDto);
        }

        // GET SINGLE PROVENANCE
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var provenance = _dBContext.Provenances.Find(id);
            var provenanceDomain = await _provenanceRepository.GetByIdAsync(id);

            if (provenanceDomain == null)
            {
                return NotFound();
            }

            // Return DTO back to Client
            return Ok(_mapper.Map<ProvenanceDTO>(provenanceDomain));
        }


        // CREATE NEW PROVENANCE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddProvenanceRequestDto addProvenanceRequestDto)
        {
            if (ModelState.IsValid)
            {
                // Map DTO to Domain Model
                var provenanceDomainModel = _mapper.Map<Provenance>(addProvenanceRequestDto);

                // Use Domain Model to create Provenance
                provenanceDomainModel = await _provenanceRepository.CreateAsync(provenanceDomainModel);

                // Map Domain Model back to DTO
                var provenanceDto = _mapper.Map<ProvenanceDTO>(provenanceDomainModel);

                return CreatedAtAction(nameof(GetById), new { id = provenanceDomainModel.Id }, provenanceDomainModel);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        // UPDATE PROVENANCE
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateProvenanceRequestDto updateProvenanceRequestDto )
        {
            // Map DTO to Domain Model
            var provenanceDomainModel = _mapper.Map<Provenance>(updateProvenanceRequestDto);

            // Check if provenance exist
            provenanceDomainModel = await _provenanceRepository.UpdateAsync(id, provenanceDomainModel);

            if( provenanceDomainModel == null )
            {
                return NotFound();
            }

            //Convert Domain Model to DTO
            var provenanceDto = _mapper.Map<ProvenanceDTO>(provenanceDomainModel);

            return Ok(provenanceDto);


        }

        // DELETE PROVENANCE
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var provenanceDomainModel = await _provenanceRepository.DeleteAsync(id);
            
            if( provenanceDomainModel == null )
            { 
                return NotFound();
            }

            // Return deleted Provenance back
            // map domain model to DTO
            return Ok(_mapper.Map<ProvenanceDTO>(provenanceDomainModel));

        }

    }
}
