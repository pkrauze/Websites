﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace WebsitesProject.Migrations
{
    [DbContext(typeof(WebsitesContext))]
    [Migration("20180103192500_AddUser")]
    partial class AddUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WebsitesProject.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<decimal>("Price");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebsitesProject.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebsitesProject.Models.Website", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Domain")
                        .IsRequired();

                    b.Property<int>("OrderID");

                    b.Property<int?>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Website");
                });

            modelBuilder.Entity("WebsitesProject.Models.Order", b =>
                {
                    b.HasOne("WebsitesProject.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("WebsitesProject.Models.Website", b =>
                {
                    b.HasOne("WebsitesProject.Models.Order", "Order")
                        .WithMany("Websites")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebsitesProject.Models.User", "User")
                        .WithMany("Websites")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
