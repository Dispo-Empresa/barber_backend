﻿// <auto-generated />
using System;
using Dispo.Barber.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Dispo.Barber.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20241008223723_Fixing")]
    partial class Fixing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.Appointment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AcceptedUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("AcceptedUserObservation")
                        .HasColumnType("text");

                    b.Property<DateTime>("AccomplishedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("BusinessUnityId")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerId")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerObservation")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AcceptedUserId");

                    b.HasIndex("BusinessUnityId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.BusinessUnity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Complement")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("BusinessUnities");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.Customer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.ServiceCompany", b =>
                {
                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("CompanyId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("CompanyServices");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.ServiceUser", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("UserServices");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("BusinessUnityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUnityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.UserSchedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<bool>("DayOff")
                        .HasColumnType("boolean");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsRest")
                        .HasColumnType("boolean");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSchedules");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("Dispo.Barber.Domain.Entities.User", "AcceptedUser")
                        .WithMany("Appointments")
                        .HasForeignKey("AcceptedUserId");

                    b.HasOne("Dispo.Barber.Domain.Entities.BusinessUnity", "BusinessUnity")
                        .WithMany()
                        .HasForeignKey("BusinessUnityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dispo.Barber.Domain.Entities.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dispo.Barber.Domain.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcceptedUser");

                    b.Navigation("BusinessUnity");

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.BusinessUnity", b =>
                {
                    b.HasOne("Dispo.Barber.Domain.Entities.Company", "Company")
                        .WithMany("BusinessUnities")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.ServiceCompany", b =>
                {
                    b.HasOne("Dispo.Barber.Domain.Entities.Company", "Company")
                        .WithMany("ServicesCompany")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dispo.Barber.Domain.Entities.Service", "Service")
                        .WithMany("CompanyServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.ServiceUser", b =>
                {
                    b.HasOne("Dispo.Barber.Domain.Entities.Service", "Service")
                        .WithMany("UserServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dispo.Barber.Domain.Entities.User", "User")
                        .WithMany("ServicesUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.User", b =>
                {
                    b.HasOne("Dispo.Barber.Domain.Entities.BusinessUnity", "BusinessUnity")
                        .WithMany("Users")
                        .HasForeignKey("BusinessUnityId");

                    b.Navigation("BusinessUnity");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.UserSchedule", b =>
                {
                    b.HasOne("Dispo.Barber.Domain.Entities.User", "User")
                        .WithMany("Schedules")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.BusinessUnity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.Company", b =>
                {
                    b.Navigation("BusinessUnities");

                    b.Navigation("ServicesCompany");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.Service", b =>
                {
                    b.Navigation("CompanyServices");

                    b.Navigation("UserServices");
                });

            modelBuilder.Entity("Dispo.Barber.Domain.Entities.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Schedules");

                    b.Navigation("ServicesUser");
                });
#pragma warning restore 612, 618
        }
    }
}
