using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Leave_Management_3.Models
{
    public partial class Umapandit_LeaveManagmentContext : DbContext
    {
        public Umapandit_LeaveManagmentContext()
        {
        }

        public Umapandit_LeaveManagmentContext(DbContextOptions<Umapandit_LeaveManagmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<LeaveApplication> LeaveApplication { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=Umapandit_LeaveManagment;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__AF2DBB99A17CC3B3");

                entity.Property(e => e.DateJoined).HasColumnType("date");

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeEmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LeaveApplication>(entity =>
            {
                entity.HasKey(e => e.LeaveId)
                    .HasName("PK__LeaveApp__796DB959AED54EC3");

                entity.Property(e => e.LeaveId).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LeaveType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerComments)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Manager__AF2DBB994F4705DB");

                entity.Property(e => e.ManagerEmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
