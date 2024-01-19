using RumProject.API.Models.Domain;

namespace RumProject.API.Repositories
{
    public interface IDistilleryRepository
    {
        Task<List<Distillery>> GetAllAsync();
        Task<Distillery?> GetByIdAsync(Guid id);
        Task<Distillery> CreateAsync(Distillery distillery);
        Task<Distillery?> UpdateAsync(Guid id,Distillery distillery);
        Task<Distillery?> DeleteAsync(Guid id);


    }
}