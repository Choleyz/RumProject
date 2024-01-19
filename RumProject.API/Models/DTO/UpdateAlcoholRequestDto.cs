namespace RumProject.API.Models.DTO
{
    public class UpdateAlcoholRequestDto
    {
        public string Category { get; set; }
        public string AlcoholDegree { get; set; }
        public string Content { get; set; }
        public DateTime? YearOfDistillation { get; set; }
        public DateTime? YearOfBottling { get; set; }
        public string? Age { get; set; }
        public string Notes { get; set; }
        public string? AlcoholImageUrl { get; set; }
        public double Price { get; set; }
        public Guid DistilleryId { get; set; }
        public Guid ProvenanceId { get; set; }

    }
}
