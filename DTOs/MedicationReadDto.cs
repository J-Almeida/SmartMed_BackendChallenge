using System;

namespace SmartMedDB.DTOs
{
    public class MedicationReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime? CreationDate { get; set; }
    }
    
}