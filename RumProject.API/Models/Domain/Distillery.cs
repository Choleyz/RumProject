namespace RumProject.API.Models.Domain
{
    public class Distillery
    {
        public Guid Id { get; set; }
        public string Bottler { get; set; }
        public string? Notes { get; set; }
        public string? DistilleryImageUrl { get; set; }



    }
}
