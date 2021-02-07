using System.Collections.Generic;
using SmartMedDB.Models;

namespace SmartMedDB.Data
{
    public interface ISmartMedDBRepo
    {
        void SaveChanges();

        IEnumerable<Medication> GetAllMedications();
        Medication GetMedicationById(int id);
        void CreateMedication(Medication medication);
        void DeleteMedicationById(int id);
    }
}