using System.ComponentModel.DataAnnotations;

namespace RumProject.API.Models.DTO
{
    public class AddProvenanceRequestDto
    {
        [Required]
        public string Country { get; set; }
        public string? ProvenanceImageUrl { get; set; }
    }
}
