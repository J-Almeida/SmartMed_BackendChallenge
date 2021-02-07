using System;
using System.Collections.Generic;
using System.Linq;
using SmartMedDB.Models;

namespace SmartMedDB.Data
{
    public class SmartMedDBRepo : ISmartMedDBRepo
    {
        public SmartMedDBContext _context { get; }

        public SmartMedDBRepo(SmartMedDBContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            // update the database
            _context.SaveChanges();
        }

        public void CreateMedication(Medication medication)
        {
            if (medication == null)
            {
                throw new ArgumentNullException(nameof(medication));
            }
            else
            {
                _context.MedicationsDbSet.Add(medication);
                SaveChanges();
            }
        }

        public IEnumerable<Medication> GetAllMedications()
        {
            return _context.MedicationsDbSet.ToList();
        }

        public Medication GetMedicationById(int id)
        {
            return _context.MedicationsDbSet.FirstOrDefault(m => m.Id == id);
        }

        public void DeleteMedicationById(int id)
        {
            Medication medication = _context.MedicationsDbSet.First(m => m.Id == id);

            if (medication != null)
            {
                _context.MedicationsDbSet.Remove(medication);
                _context.SaveChanges();
            }
            
        }
    }
}