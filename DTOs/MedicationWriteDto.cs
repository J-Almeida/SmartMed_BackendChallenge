using System;
using System.ComponentModel.DataAnnotations;

namespace SmartMedDB.DTOs
{
    // to write a new medication, only the name and quantity are included
    public class MedicationWriteDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, Double.PositiveInfinity)]
        public int Quantity { get; set; }
    }
    
}