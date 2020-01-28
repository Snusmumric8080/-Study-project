namespace WebApplication16.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model12")
        {
        }

        public virtual DbSet<Attendance1> Attendance1 { get; set; }
        public virtual DbSet<AttendanceStudent> AttendanceStudents { get; set; }
        public virtual DbSet<Progress> Progresses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public object Attendance { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance1>()
                .HasMany(e => e.AttendanceStudents)
                .WithRequired(e => e.Attendance1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AttendanceStudent>()
                .Property(e => e.Status)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e.FullNameStudent)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Town)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Home)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.TeacherFullName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.PlaseOfBirt)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.DateOfBirt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FullNameMother)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.NumerMother)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.PlaseWorkMother)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FullNameFather)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.NumberFather)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.PlaseWorkFather)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Mail)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.AttendanceStudents)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Progresses)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .Property(e => e.NameSubject)
                .IsUnicode(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Progresses)
                .WithRequired(e => e.Subject)
                .WillCascadeOnDelete(false);

          

        }
      
    }
}
