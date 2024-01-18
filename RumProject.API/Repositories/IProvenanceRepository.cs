using RumProject.API.Models.Domain;

namespace RumProject.API.Repositories
{
    public interface IProvenanceRepository
    {
        Task<List<Provenance>> GetAllAsync();

        Task<Provenance?> GetByIdAsync(Guid guid);

        Task<Provenance> CreateAsync(Provenance provenance);

        Task<Provenance?> UpdateAsync(Guid id, Provenance provenance);

        Task<Provenance?> DeleteAsync(Guid id);
    }
}
