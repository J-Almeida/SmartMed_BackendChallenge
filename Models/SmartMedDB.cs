using System;
using System.ComponentModel.DataAnnotations;

namespace SmartMedDB.Models
{
    public class Medication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        // "The quantity must be greater than zero"
        [Range(1, Double.PositiveInfinity)]
        public int Quantity { get; set; }
        // The creation date may be null
        public DateTime? CreationDate { get; set; }

    }
}