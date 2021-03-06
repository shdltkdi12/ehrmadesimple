﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ehrmadesimple.Data;

namespace ehrmadesimple.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200701093017_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ehrmadesimple.Models.Appointment", b =>
                {
                    b.Property<string>("AppointmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BillId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Clientname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isAllDay")
                        .HasColumnType("bit");

                    b.Property<bool>("isRepeating")
                        .HasColumnType("bit");

                    b.HasKey("AppointmentId");

                    b.HasIndex("BillId");

                    b.HasIndex("ClientId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ehrmadesimple.Models.Bill", b =>
                {
                    b.Property<string>("BillId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BillingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("money");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("isPaid")
                        .HasColumnType("bit");

                    b.HasKey("BillId");

                    b.HasIndex("ClientId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("ehrmadesimple.Models.Client", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BillingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DiagnosisTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("FirstJoined")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ehrmadesimple.Models.ClientInfo", b =>
                {
                    b.Property<int>("ClientInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BdayDay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BdayMonth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BdayYear")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EmergencyEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyFname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyLname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmergencyRelationship")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmploymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationshipStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zip")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientInfoId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientInfoes");
                });

            modelBuilder.Entity("ehrmadesimple.Models.Event", b =>
                {
                    b.Property<int>("RowNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Crud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Table")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.HasKey("RowNumber");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ehrmadesimple.Models.InitialQuestionAnswer", b =>
                {
                    b.Property<int>("RowNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Extra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralSymptoms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InitialDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LivingStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicationDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OccupationDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PastMonthSymptoms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrescribingMdDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryPhysicianDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RelationshipDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("isAlcohol")
                        .HasColumnType("bit");

                    b.Property<bool>("isAttemptedSuicide")
                        .HasColumnType("bit");

                    b.Property<bool>("isConsultedBefore")
                        .HasColumnType("bit");

                    b.Property<bool>("isDrug")
                        .HasColumnType("bit");

                    b.Property<bool>("isFamilyMemberIll")
                        .HasColumnType("bit");

                    b.Property<bool>("isHarmOthers")
                        .HasColumnType("bit");

                    b.Property<bool>("isHospitalized")
                        .HasColumnType("bit");

                    b.Property<bool>("isSuicidal")
                        .HasColumnType("bit");

                    b.HasKey("RowNumber");

                    b.HasIndex("ClientId");

                    b.ToTable("InitialQuestionAnswers");
                });

            modelBuilder.Entity("ehrmadesimple.Models.Session", b =>
                {
                    b.Property<int>("RowNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppointmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgressNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PsychoNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("RowNumber");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ClientId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ehrmadesimple.Models.Appointment", b =>
                {
                    b.HasOne("ehrmadesimple.Models.Bill", "Bill")
                        .WithMany("Appointments")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ehrmadesimple.Models.Client", "Client")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("ehrmadesimple.Models.Bill", b =>
                {
                    b.HasOne("ehrmadesimple.Models.Client", "Client")
                        .WithMany("Bills")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ehrmadesimple.Models.ClientInfo", b =>
                {
                    b.HasOne("ehrmadesimple.Models.Client", "Client")
                        .WithMany("ClientInfoes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ehrmadesimple.Models.InitialQuestionAnswer", b =>
                {
                    b.HasOne("ehrmadesimple.Models.Client", "Client")
                        .WithMany("InitialQuestionAnswers")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ehrmadesimple.Models.Session", b =>
                {
                    b.HasOne("ehrmadesimple.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId");

                    b.HasOne("ehrmadesimple.Models.Client", "Client")
                        .WithMany("Sessions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
