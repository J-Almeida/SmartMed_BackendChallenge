using System;
using System.ComponentModel.DataAnnotations;

namespace SmartMedDB.DTOs
{
    public class MedicationWriteDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, Double.PositiveInfinity)]
        public int Quantity { get; set; }
    }
    
}