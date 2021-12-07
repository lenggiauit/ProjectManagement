using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace PM.API.Domain.Entities.Update
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
        public virtual DbSet<Conversation> Conversation { get; set; }
        public virtual DbSet<ConversationMessage> ConversationMessage { get; set; }
        public virtual DbSet<ConversationUsers> ConversationUsers { get; set; }
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
        public virtual DbSet<UserOnProject> UserOnProject { get; set; }
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

                entity.Property(e => e.Comment1).HasColumnName("Comment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Conversation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastMessage).HasMaxLength(500);

                entity.Property(e => e.LastMessageDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<ConversationMessage>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LovedByUids)
                    .HasColumnName("LovedByUIds")
                    .HasMaxLength(1000);

                entity.Property(e => e.Message).HasMaxLength(1500);

                entity.Property(e => e.SeenByUids)
                    .HasColumnName("SeenByUIds")
                    .HasMaxLength(1000);

                entity.Property(e => e.SendDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ConversationUsers>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PermissionInRole>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionInRole)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__Permi__2DE6D218");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionInRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Permissio__RoleI__2EDAF651");
            });

            modelBuilder.Entity<Priority>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Project__StatusI__76969D2E");
            });

            modelBuilder.Entity<ProjectStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.IsSystemRole).HasDefaultValueSql("((0))");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsPublic).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Todo>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<TodoType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Color).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(250);

                entity.Property(e => e.Avatar).HasMaxLength(255);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FullName).HasMaxLength(150);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.JobTitle).HasMaxLength(250);

                entity.Property(e => e.Password).HasMaxLength(250);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.UserName).HasMaxLength(250);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__User__RoleId__1EA48E88");
            });

            modelBuilder.Entity<UserOnProject>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.UserOnProject)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOnPro__Proje__3F115E1A");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserOnProject)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOnPro__RoleI__40058253");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserOnProject)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserOnPro__UserI__3E1D39E1");
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
