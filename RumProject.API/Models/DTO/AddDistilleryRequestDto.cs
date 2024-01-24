using System.ComponentModel.DataAnnotations;

namespace RumProject.API.Models.DTO
{
    public class AddDistilleryRequestDto
    {
        [Required]
        public string Bottler { get; set; }
        public string? Notes { get; set; }
        public string? DistilleryImageUrl { get; set; }
    }
}
