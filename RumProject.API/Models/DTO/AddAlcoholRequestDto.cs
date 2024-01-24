using System.ComponentModel.DataAnnotations;

namespace RumProject.API.Models.DTO
{
    public class AddAlcoholRequestDto
    {
        [Required]
        public string Category { get; set; }
        [Required]
        public string AlcoholDegree { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime? YearOfDistillation { get; set; }
        public DateTime? YearOfBottling { get; set; }
        public string? Age { get; set; }
        [Required]
        public string Notes { get; set; }
        public string? AlcoholImageUrl { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Guid DistilleryId { get; set; }
        [Required]
        public Guid ProvenanceId { get; set; }

    }
}
