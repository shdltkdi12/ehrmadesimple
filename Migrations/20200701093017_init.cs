using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ehrmadesimple.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    BillingType = table.Column<string>(nullable: true),
                    FirstJoined = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    Diagnosis = table.Column<string>(nullable: true),
                    DiagnosisTimestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    RowNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Crud = table.Column<string>(nullable: true),
                    Table = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.RowNumber);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<string>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    Fee = table.Column<decimal>(type: "money", nullable: false),
                    isPaid = table.Column<bool>(nullable: false),
                    BillingType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK_Bills_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientInfoes",
                columns: table => new
                {
                    ClientInfoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(nullable: true),
                    ClientEmail = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    BdayMonth = table.Column<string>(nullable: true),
                    BdayDay = table.Column<string>(nullable: true),
                    BdayYear = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true),
                    RelationshipStatus = table.Column<string>(nullable: true),
                    EmploymentStatus = table.Column<string>(nullable: true),
                    EmergencyFname = table.Column<string>(nullable: true),
                    EmergencyLname = table.Column<string>(nullable: true),
                    EmergencyRelationship = table.Column<string>(nullable: true),
                    EmergencyEmail = table.Column<string>(nullable: true),
                    EmergencyPhone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientInfos", x => x.ClientInfoId);
                    table.ForeignKey(
                        name: "FK_ClientInfos_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InitialQuestionAnswers",
                columns: table => new
                {
                    RowNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    InitialDetails = table.Column<string>(nullable: true),
                    isConsultedBefore = table.Column<bool>(nullable: false),
                    MedicationDetails = table.Column<string>(nullable: true),
                    PrescribingMdDetails = table.Column<string>(nullable: true),
                    PrimaryPhysicianDetails = table.Column<string>(nullable: true),
                    isAlcohol = table.Column<bool>(nullable: false),
                    isDrug = table.Column<bool>(nullable: false),
                    isSuicidal = table.Column<bool>(nullable: false),
                    isAttemptedSuicide = table.Column<bool>(nullable: false),
                    isHarmOthers = table.Column<bool>(nullable: false),
                    isHospitalized = table.Column<bool>(nullable: false),
                    isFamilyMemberIll = table.Column<bool>(nullable: false),
                    RelationshipDetails = table.Column<string>(nullable: true),
                    LivingStatus = table.Column<string>(nullable: true),
                    OccupationDetails = table.Column<string>(nullable: true),
                    PastMonthSymptoms = table.Column<string>(nullable: true),
                    GeneralSymptoms = table.Column<string>(nullable: true),
                    Extra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialQuestionAnswers", x => x.RowNumber);
                    table.ForeignKey(
                        name: "FK_InitialQuestionAnswers_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<string>(nullable: false),
                    Clientname = table.Column<string>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    isAllDay = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    isRepeating = table.Column<bool>(nullable: false),
                    ServiceType = table.Column<string>(nullable: true),
                    BillId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Bills_BillId",
                        column: x => x.BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    RowNumber = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Diagnosis = table.Column<string>(nullable: true),
                    ProgressNote = table.Column<string>(nullable: true),
                    PsychoNote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.RowNumber);
                    table.ForeignKey(
                        name: "FK_Sessions_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BillId",
                table: "Appointments",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClientId",
                table: "Appointments",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ClientId",
                table: "Bills",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientInfos_ClientId",
                table: "ClientInfoes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InitialQuestionAnswers_ClientId",
                table: "InitialQuestionAnswers",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AppointmentId",
                table: "Sessions",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ClientId",
                table: "Sessions",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientInfoes");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "InitialQuestionAnswers");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
