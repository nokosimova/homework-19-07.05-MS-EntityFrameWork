using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ConsoleApp1
{
    public partial class NewDBContext : DbContext
    {
        public NewDBContext()
        {
        }

        public NewDBContext(DbContextOptions<NewDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CourseList> CourseList { get; set; }
        public virtual DbSet<MarkList> MarkList { get; set; }
        public virtual DbSet<StudentList> StudentList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data source=KosimovaNodira; Initial catalog = NewDB; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseList>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__CourseLi__C92D71A7E8AB2411");

                entity.Property(e => e.CourseName).HasMaxLength(50);
            });

            modelBuilder.Entity<MarkList>(entity =>
            {
                entity.HasKey(e => e.MarkId)
                    .HasName("PK__MarkList__8C09C487A968C4E2");

                entity.Property(e => e.MarkId).HasColumnName("markId");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.MarkList)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__MarkList__Course__59063A47");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.MarkList)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__MarkList__Studen__5812160E");
            });

            modelBuilder.Entity<StudentList>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MidName).HasMaxLength(50);

                entity.Property(e => e.Telephone).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
