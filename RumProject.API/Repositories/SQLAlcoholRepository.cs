using Microsoft.EntityFrameworkCore;
using RumProject.API.Data;
using RumProject.API.Models.Domain;

namespace RumProject.API.Repositories
{
    public class SQLAlcoholRepository : IAlcoholRepository
    {
        private readonly RumProjectDBContext _dbContext;

        public SQLAlcoholRepository(RumProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Alcohol>> GetAllAsync()
        {
            return await _dbContext.Alcohols.Include("Distillery").Include("Provenance").ToListAsync();

        }
        public async Task<Alcohol?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Alcohols.Include("Provenance").Include("Distillery").FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Alcohol> CreateAsync(Alcohol alcohol)
        {
            await _dbContext.Alcohols.AddAsync(alcohol);
            await _dbContext.SaveChangesAsync();
            return alcohol;
        }

        public async Task<Alcohol?> UpdateAsync(Guid id, Alcohol alcohol)
        {
            var existingAlcohol = await _dbContext.Alcohols.FirstOrDefaultAsync(x => x.Id ==  id);

            if (existingAlcohol == null)
            {
                return null;
            }

            existingAlcohol.Category = alcohol.Category;
            existingAlcohol.AlcoholDegree = alcohol.AlcoholDegree;
            existingAlcohol.Content = alcohol.Content;
            existingAlcohol.YearOfDistillation = alcohol.YearOfDistillation;
            existingAlcohol.YearOfBottling = alcohol.YearOfBottling;
            existingAlcohol.Age = alcohol.Age;
            existingAlcohol.Notes = alcohol.Notes;
            existingAlcohol.AlcoholImageUrl = alcohol.AlcoholImageUrl;
            existingAlcohol.Price = alcohol.Price;
            existingAlcohol.DistilleryId = alcohol.DistilleryId;
            existingAlcohol.ProvenanceId = alcohol.ProvenanceId;

            await _dbContext.SaveChangesAsync();

            return existingAlcohol;


        }

        public async Task<Alcohol?> DeleteAsync(Guid id)
        {
            var existingAlcohol = await _dbContext.Alcohols.FirstOrDefaultAsync(x => x.Id == id);
            
            if (existingAlcohol == null)
            {
                return null;
            }

            _dbContext.Alcohols.Remove(existingAlcohol);
            await _dbContext.SaveChangesAsync();
            return existingAlcohol;
        }
    }
}
