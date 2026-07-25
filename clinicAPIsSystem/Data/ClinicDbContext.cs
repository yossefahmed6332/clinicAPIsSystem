using clinicAPIsSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using clinicAPIsSystem.Models.User;
using clinicAPIsSystem.Models.User.MedicalStaff;
using clinicAPIsSystem.Models.User.NonMedicalStaff;
namespace clinicAPIsSystem.Data
{
    public class ClinicDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Doctor> TDoctors { get; set; }
        public virtual DbSet<Nurse> TNurses { get; set; }
        public virtual DbSet<Accountant> TAccountants { get; set; }
        public virtual DbSet<Cleaner> TCleaners { get; set; }
        public virtual DbSet<Medical> TMedicals { get; set; }
        public virtual DbSet<Patient> TPatients { get; set; }
        public virtual DbSet<Prescription> TPrescriptions { get; set; }
        public virtual DbSet<Appointment> TAppointments { get; set; }
        public virtual DbSet<Operation> TOperations { get; set; }
        public virtual DbSet<Qualification> TQualifications { get; set; }
        public virtual DbSet<Specialization> TSpecializations { get; set; }


    }
}