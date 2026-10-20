using HealthCareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareApi.Data;

public class HealthCareDbContext : DbContext
{
    public HealthCareDbContext(DbContextOptions<HealthCareDbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Patient>()
            .Property(patient => patient.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Doctor>()
            .Property(doctor => doctor.Specialization)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Appointment>()
            .HasKey(appointment => new
            {
                appointment.PatientId,
                appointment.DoctorId,
                appointment.AppointmentDate
            });

        modelBuilder.Entity<Appointment>()
            .HasOne(appointment => appointment.Patient)
            .WithMany(patient => patient.Appointments)
            .HasForeignKey(appointment => appointment.PatientId);

        modelBuilder.Entity<Appointment>()
            .HasOne(appointment => appointment.Doctor)
            .WithMany(doctor => doctor.Appointments)
            .HasForeignKey(appointment => appointment.DoctorId);
    }
}
