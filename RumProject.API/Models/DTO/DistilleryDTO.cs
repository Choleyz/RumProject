﻿namespace RumProject.API.Models.DTO
{
    public class DistilleryDTO
    {
        public Guid Id { get; set; }
        public string Bottler { get; set; }
        public string? Notes { get; set; }
        public string? DistilleryImageUrl { get; set; }


    }
}
