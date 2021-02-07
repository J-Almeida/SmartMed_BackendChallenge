using System;
using System.Collections.Generic;
using SmartMedDB.Models;

namespace SmartMedDB.Data
{
    public class MockSmartMedDBRepo : ISmartMedDBRepo
    {
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void CreateMedication(Medication medication)
        {
            throw new NotImplementedException();
        }        

        public IEnumerable<Medication> GetAllMedications()
        {
            var medications = new List<Medication>
            {
                new Medication
                {
                    Id = 1,
                    Name = "Cool Ibuprofen",
                    Quantity=123,
                    CreationDate=new DateTime(2021, 02, 06)
                },

                new Medication
                {
                    Id = 2,
                    Name = "Fast Aspirin",
                    Quantity=456,
                    CreationDate=new DateTime(2021, 02, 05)
                },

                new Medication
                {
                    Id = 3,
                    Name = "Super Antihistamine",
                    Quantity=789,
                    CreationDate=new DateTime(2021, 02, 04)
                }
            };

            return medications;
        }

        public Medication GetMedicationById(int id)
        {
            return new Medication{
                Name = "medication name",
                Quantity=123,
                CreationDate=new DateTime(2021, 02, 06)
                };
        }

        public void DeleteMedicationById(int id)
        {
            throw new NotImplementedException();
        }
    }
}