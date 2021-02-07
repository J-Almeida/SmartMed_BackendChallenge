using System.Collections.Generic;
using SmartMedDB.Models;

namespace SmartMedDB.Data
{
    public interface ISmartMedDBRepo
    {
        // pushes all the changes to the database
        void SaveChanges();

        // gets all the medications present in the database
        IEnumerable<Medication> GetAllMedications();

        // gets the medication with the matching ID
        Medication GetMedicationById(int id);

        // adds the given medication to the database
        void CreateMedication(Medication medication);

        // deletes the indicated medication from the database
        void DeleteMedicationById(int id);
    }
}