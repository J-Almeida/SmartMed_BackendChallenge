using Microsoft.EntityFrameworkCore;
using SmartMedDB.Models;

namespace SmartMedDB.Data
{
    public class SmartMedDBContext : DbContext
    {
        public SmartMedDBContext(DbContextOptions<SmartMedDBContext> opt)
            : base(opt)
        {
            
        }

        public DbSet<Medication> MedicationsDbSet { get; set; }
    }
}