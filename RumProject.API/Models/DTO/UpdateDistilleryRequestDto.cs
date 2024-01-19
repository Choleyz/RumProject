namespace RumProject.API.Models.DTO
{
    public class UpdateDistilleryRequestDto
    {
        public string Bottler { get; set; }
        public string? Notes { get; set; }
        public string? DistilleryImageUrl { get; set; }
    }
}
