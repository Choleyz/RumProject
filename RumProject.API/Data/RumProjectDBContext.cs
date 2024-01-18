using Microsoft.EntityFrameworkCore;
using RumProject.API.Models.Domain;

namespace RumProject.API.Data
{
    public class RumProjectDBContext : DbContext
    {
        public RumProjectDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Alcohol> Alcohols { get; set; }
        public DbSet<Distillery> Distilleries { get; set; }
        public DbSet<Provenance> Provenances { get; set; }
    }
}
