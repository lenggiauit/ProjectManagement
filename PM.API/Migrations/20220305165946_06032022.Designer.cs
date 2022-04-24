﻿// <auto-generated />
using System;
using CV.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CV.API.Migrations
{
    [DbContext(typeof(PMContext))]
    [Migration("20220305165946_06032022")]
    partial class _06032022
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CV.API.Domain.Entities.Comment", b =>
                {
                    b.Property<string>("CommentContent")
                        .HasColumnName("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Control", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ControlId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EditType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Placeholder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ControlId");

                    b.ToTable("Control");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Conversation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("LastMessage")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime?>("LastMessageDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Conversation");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.ConversationMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LovedByUids")
                        .HasColumnName("LovedByUIds")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(1500)")
                        .HasMaxLength(1500);

                    b.Property<string>("SeenByUids")
                        .HasColumnName("SeenByUIds")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("SendDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ConversationMessage");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.ConversationUsers", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ConversationUsers");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nchar(50)")
                        .IsFixedLength(true)
                        .HasMaxLength(50);

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.PermissionInRole", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("PermissionInRole");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Priority", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Priority");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.ProjectStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ProjectStatus");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSystemRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPublic")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsArchived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid?>("LayoutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PackagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TemplateTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LayoutId");

                    b.HasIndex("TemplateTypeId");

                    b.ToTable("Template");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.TemplateType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool?>("IsArchived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TemplateType");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Assignee")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssigneeNavigationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("PositionH")
                        .HasColumnType("int");

                    b.Property<int?>("PositionW")
                        .HasColumnType("int");

                    b.Property<int?>("PositionX")
                        .HasColumnType("int");

                    b.Property<int?>("PositionY")
                        .HasColumnType("int");

                    b.Property<Guid?>("PriorityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("TodoStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TodoTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AssigneeNavigationId");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("TodoStatusId");

                    b.HasIndex("TodoTypeId");

                    b.ToTable("Todo");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.TodoStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TodoStatus");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.TodoType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TodoType");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Phone")
                        .HasColumnType("nchar(20)")
                        .IsFixedLength(true)
                        .HasMaxLength(20);

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("ConversationId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.UserOnProject", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOnProject");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.UserOnTeam", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOnTeam");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Control", b =>
                {
                    b.HasOne("CV.API.Domain.Entities.Control", null)
                        .WithMany("Childs")
                        .HasForeignKey("ControlId");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.PermissionInRole", b =>
                {
                    b.HasOne("CV.API.Domain.Entities.Permission", "Permission")
                        .WithMany("PermissionInRole")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CV.API.Domain.Entities.Role", "Role")
                        .WithMany("PermissionInRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Project", b =>
                {
                    b.HasOne("CV.API.Domain.Entities.ProjectStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Template", b =>
                {
                    b.HasOne("CV.API.Domain.Entities.Control", "Layout")
                        .WithMany()
                        .HasForeignKey("LayoutId");

                    b.HasOne("CV.API.Domain.Entities.TemplateType", "TemplateType")
                        .WithMany()
                        .HasForeignKey("TemplateTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CV.API.Domain.Entities.Todo", b =>
                {
                    b.HasOne("CV.API.Domain.Entities.User", "AssigneeNavigation")
                        .WithMany()
                        .HasForeignKey("AssigneeNavigationId");

                    b.HasOne("CV.API.Domain.Entities.Priority", "Priority")
                        .WithMany()
                        .HasForeignKey("PriorityId");

                    b.HasOne("CV.API.Domain.Entities.Project", "Project")
                        .WithMany("Todo")
                        .HasForeignKey("ProjectId");

                    b.HasOne("CV.API.Domain.Entities.TodoStatus", "TodoStatus")
                        .WithMany("Todo")
                        .HasForeignKey("TodoStatusId");

                    b.HasOne("CV.API.Domain.Entities.TodoType", "TodoType")
                        .WithMany("Todo")
                        .HasForeignKey("TodoTypeId");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.User", b =>
                {
                    b.HasOne("CV.API.Domain.Entities.Conversation", null)
                        .WithMany("Conversationers")
                        .HasForeignKey("ConversationId");

                    b.HasOne("CV.API.Domain.Entities.Project", null)
                        .WithMany("Members")
                        .HasForeignKey("ProjectId");

                    b.HasOne("CV.API.Domain.Entities.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("CV.API.Domain.Entities.UserOnProject", b =>
                {
                    b.HasOne("CV.API.Domain.Entities.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CV.API.Domain.Entities.Role", "Role")
                        .WithMany("UserOnProject")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CV.API.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CV.API.Domain.Entities.UserOnTeam", b =>
                {
                    b.HasOne("CV.API.Domain.Entities.Team", "Team")
                        .WithMany("UserOnTeam")
                        .HasForeignKey("TeamId");

                    b.HasOne("CV.API.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
