namespace RumProject.API.Models.DTO
{
    public class AddDistilleryRequestDto
    {
        public string Bottler { get; set; }
        public string? Notes { get; set; }
        public string? DistilleryImageUrl { get; set; }
    }
}
