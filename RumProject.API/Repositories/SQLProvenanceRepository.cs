using Microsoft.EntityFrameworkCore;
using RumProject.API.Data;
using RumProject.API.Models.Domain;

namespace RumProject.API.Repositories
{
    public class SQLProvenanceRepository : IProvenanceRepository
    {
        private readonly RumProjectDBContext _dbContext;

        public SQLProvenanceRepository(RumProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Provenance> CreateAsync(Provenance provenance)
        {
            await _dbContext.Provenances.AddAsync(provenance);
            await _dbContext.SaveChangesAsync();
            return provenance;
        }

        public async Task<Provenance?> DeleteAsync(Guid id)
        {
            var existingProvenance = _dbContext.Provenances.FirstOrDefault(p => p.Id == id);
            if (existingProvenance == null)
            {
                return null;
            }

            _dbContext.Provenances.Remove(existingProvenance);
            await _dbContext.SaveChangesAsync();
            return existingProvenance;
        }

        public async Task<List<Provenance>> GetAllAsync()
        {
            return await _dbContext.Provenances.ToListAsync();
        }

        public async Task<Provenance?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Provenances.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Provenance?> UpdateAsync(Guid id, Provenance provenance)
        {
            var existingProvenance = await _dbContext.Provenances.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProvenance == null)
            {
                return null;
            }

            existingProvenance.Country = provenance.Country;
            existingProvenance.ProvenanceImageUrl = provenance.ProvenanceImageUrl;

            await _dbContext.SaveChangesAsync();
            return existingProvenance;
        }
    }

}