using Hospital.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hospital.Repositonries
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<ApplecationUser> applecationUsers { get; set; }
        public DbSet<Appointment>Appointments { get; set; }
        public DbSet<Bill>Bills { get; set; }
        public DbSet<Contact>Contacts { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<HospitalInfo>Hospitals { get; set; }
        public DbSet<Room>Rooms { get; set; }
        public DbSet<Insurance>Insurances { get; set; }
        public DbSet<Lap>Laps { get; set; }
        public DbSet<PataintReport>PataintReports { get; set; }
        public DbSet<Medicine>Medicines { get; set; }
        public DbSet<MedicineReport>MedicineReports { get; set; }
        public DbSet<PrescribedMedicine>PrescribedMedicines { get; set; }
        public DbSet<Payroll>Payrolls { get; set; }
        public DbSet<Supplier>Suppliers{ get; set; }
        public DbSet<TestPrice>TestPrices { get; set; }
        

    }
}
