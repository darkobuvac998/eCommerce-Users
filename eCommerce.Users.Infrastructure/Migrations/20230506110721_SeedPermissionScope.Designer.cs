﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using eCommerce.Users.Infrastructure.Contexts;

#nullable disable

namespace eCommerce.Users.Infrastructure.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    [Migration("20230506110721_SeedPermissionScope")]
    partial class SeedPermissionScope
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_permissions");

                    b.ToTable("permissions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Product-[Add,View,Edit,Delete]"
                        });
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.PermissionScope", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("integer")
                        .HasColumnName("permission_id");

                    b.Property<int>("ScopeId")
                        .HasColumnType("integer")
                        .HasColumnName("scope_id");

                    b.HasKey("PermissionId", "ScopeId")
                        .HasName("pk_permission_scope");

                    b.HasIndex("ScopeId")
                        .HasDatabaseName("ix_permission_scope_scope_id");

                    b.ToTable("permission_scope", (string)null);

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            ScopeId = 1
                        },
                        new
                        {
                            PermissionId = 1,
                            ScopeId = 2
                        },
                        new
                        {
                            PermissionId = 1,
                            ScopeId = 3
                        },
                        new
                        {
                            PermissionId = 1,
                            ScopeId = 4
                        });
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer")
                        .HasColumnName("permission_id");

                    b.HasKey("Id")
                        .HasName("pk_resources");

                    b.HasIndex("PermissionId")
                        .IsUnique()
                        .HasDatabaseName("ix_resources_permission_id");

                    b.ToTable("resources", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Product",
                            PermissionId = 1
                        });
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Techincal"
                        },
                        new
                        {
                            Id = 3,
                            Name = "CustomerBasic"
                        },
                        new
                        {
                            Id = 4,
                            Name = "CustomerGold"
                        },
                        new
                        {
                            Id = 5,
                            Name = "CustomerPremium"
                        });
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.RolePermission", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("integer")
                        .HasColumnName("permission_id");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.HasKey("PermissionId", "RoleId")
                        .HasName("pk_role_permission");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("ix_role_permission_role_id");

                    b.ToTable("role_permission", (string)null);
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.Scope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_scopes");

                    b.ToTable("scopes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Edit"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Add"
                        },
                        new
                        {
                            Id = 3,
                            Name = "View"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delete"
                        });
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool?>("EmailVerified")
                        .HasColumnType("boolean")
                        .HasColumnName("email_verified");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasDatabaseName("ix_users_username");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.UserRoles", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer")
                        .HasColumnName("role_id");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("RoleId", "UserId")
                        .HasName("pk_user_roles");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_roles_user_id");

                    b.ToTable("user_roles", (string)null);
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.PermissionScope", b =>
                {
                    b.HasOne("eCommerce.Users.Domain.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_permission_scope_permissions_permission_id");

                    b.HasOne("eCommerce.Users.Domain.Entities.Scope", null)
                        .WithMany()
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_permission_scope_scopes_scope_id");
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.Resource", b =>
                {
                    b.HasOne("eCommerce.Users.Domain.Entities.Permission", "Permission")
                        .WithOne("Resource")
                        .HasForeignKey("eCommerce.Users.Domain.Entities.Resource", "PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_resources_permissions_permission_id");

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.RolePermission", b =>
                {
                    b.HasOne("eCommerce.Users.Domain.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_permission_permissions_permission_id");

                    b.HasOne("eCommerce.Users.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_role_permission_roles_role_id");
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.UserRoles", b =>
                {
                    b.HasOne("eCommerce.Users.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_roles_role_id");

                    b.HasOne("eCommerce.Users.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_roles_users_user_id");
                });

            modelBuilder.Entity("eCommerce.Users.Domain.Entities.Permission", b =>
                {
                    b.Navigation("Resource")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
