using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities
{
    public partial class PMContext : DbContext
    {
        public PMContext()
        {
        }

        public PMContext(DbContextOptions<PMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<PermissionInRole> PermissionInRole { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<ProjectStatus> ProjectStatus { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Todo> Todo { get; set; }
        public virtual DbSet<TodoStatus> TodoStatus { get; set; }
        public virtual DbSet<TodoType> TodoType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserOnTeam> UserOnTeam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-5D7UDNH\\SQLEXPRESS;Database=ProjectManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code).IsFixedLength();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<PermissionInRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionInRole)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__Permi__18EBB532");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionInRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__RoleI__19DFD96B");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Project__StatusI__76969D2E");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsPublic).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.AssigneeNavigation)
                    .WithMany(p => p.Todo)
                    .HasForeignKey(d => d.Assignee)
                    .HasConstraintName("FK__Todo__Assignee__0B91BA14");

                entity.HasOne(d => d.Priority)
                    .WithMany(p => p.Todo)
                    .HasForeignKey(d => d.PriorityId)
                    .HasConstraintName("FK__Todo__PriorityId__0C85DE4D");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Todo)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK__Todo__ProjectId__0D7A0286");

                entity.HasOne(d => d.TodoStatus)
                    .WithMany(p => p.Todo)
                    .HasForeignKey(d => d.TodoStatusId)
                    .HasConstraintName("FK__Todo__TodoStatus__0E6E26BF");

                entity.HasOne(d => d.TodoType)
                    .WithMany(p => p.Todo)
                    .HasForeignKey(d => d.TodoTypeId)
                    .HasConstraintName("FK__Todo__TodoTypeId__0F624AF8");
            });

            modelBuilder.Entity<TodoStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<TodoType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__1EA48E88");
            });

            modelBuilder.Entity<UserOnTeam>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.UserOnTeam)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__UserOnTea__TeamI__1CBC4616");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOnTeam)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserOnTea__UserI__1DB06A4F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
