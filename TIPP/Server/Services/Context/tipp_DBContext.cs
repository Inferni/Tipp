using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TIPP.Shared;

#nullable disable

namespace TIPP.Server.Domain
{
    public partial class tipp_DBContext : DbContext
    {
        //public tipp_DBContext()
        //{
        //}

        public tipp_DBContext(DbContextOptions<tipp_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Milestone> Milestones { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectUser> ProjectUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //                optionsBuilder.UseSqlServer("Server=tcp:tipp.database.windows.net,1433;Database=tipp_DB;Integrated Security=True;Trusted_Connection=False;Encrypt=True;User ID=tipp_min;Password=6qVo8UDZokVQoOQVd6TG");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activities_Project");
            });

            modelBuilder.Entity<Milestone>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TimeSpent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProjectUser>(entity =>
            {

                entity.ToTable("ProjectUser");

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Project)
                    .OnDelete(DeleteBehavior.NoAction);
                    //.HasConstraintName("FK_ProjectUser_Project");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.User)
                    .OnDelete(DeleteBehavior.NoAction);
                    //.HasConstraintName("FK_ProjectUser_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Role).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
