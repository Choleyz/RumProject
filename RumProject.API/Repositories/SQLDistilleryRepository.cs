using Microsoft.EntityFrameworkCore;
using RumProject.API.Data;
using RumProject.API.Models.Domain;

namespace RumProject.API.Repositories
{
    public class SQLDistilleryRepository : IDistilleryRepository
    {
        private readonly RumProjectDBContext _dbContext;

        public SQLDistilleryRepository(RumProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Distillery> CreateAsync(Distillery distillery)
        {
            await _dbContext.Distilleries.AddAsync(distillery);
            await _dbContext.SaveChangesAsync();
            return distillery;
        }

        public async Task<Distillery?> DeleteAsync(Guid id)
        {
            var existingDistillery = await _dbContext.Distilleries.FirstOrDefaultAsync(x  => x.Id == id);
            if (existingDistillery == null)
            {
                return null;
            }
            _dbContext.Distilleries.Remove(existingDistillery);
            await _dbContext.SaveChangesAsync();
            return existingDistillery;

        }

        public async Task<List<Distillery>> GetAllAsync()
        {
            return await _dbContext.Distilleries.ToListAsync();
        }

        public async Task<Distillery?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Distilleries.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Distillery?> UpdateAsync(Guid id, Distillery distillery)
        {
            var existingDistillery = await _dbContext.Distilleries.FirstOrDefaultAsync(x => x.Id == id);
            if (existingDistillery == null)
            {
                return null;
            }
            existingDistillery.Bottler = distillery.Bottler;
            existingDistillery.Notes = distillery.Notes;
            existingDistillery.DistilleryImageUrl = distillery.DistilleryImageUrl;

            await _dbContext.SaveChangesAsync();
            return existingDistillery;

        }
    }
}
