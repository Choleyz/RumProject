using RumProject.API.Models.Domain;

namespace RumProject.API.Repositories
{
    public interface IAlcoholRepository
    {
        Task<List<Alcohol>> GetAllAsync();
        Task<Alcohol?> GetByIdAsync(Guid id);
        Task<Alcohol> CreateAsync(Alcohol alcohol);
        Task<Alcohol?> UpdateAsync(Guid guid, Alcohol alcohol);
        Task<Alcohol?> DeleteAsync(Guid id);

    }
}
