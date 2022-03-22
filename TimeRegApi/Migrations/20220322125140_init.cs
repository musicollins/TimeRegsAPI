using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeRegApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GitHub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aktiv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    TimeReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationHours = table.Column<int>(type: "int", nullable: false),
                    PreperationHours = table.Column<int>(type: "int", nullable: false),
                    Other = table.Column<int>(type: "int", nullable: false),
                    AfterHours = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.TimeReportId);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Test@test.se", "Filip", "Lindberg", "112233", 112 },
                    { 2, "Test2@test.se", "Andre", "Lindqvist", "332211", 112 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Aktiv", "Company", "Deadline", "GitHub", "ProjectName" },
                values: new object[,]
                {
                    { 1, true, "Aveer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Länk", "Test" },
                    { 2, false, "Aveer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Länk 2", "Testing" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportId", "AfterHours", "Comment", "EducationHours", "Other", "PreperationHours" },
                values: new object[,]
                {
                    { 1, 2, "Testing", 0, 0, 0 },
                    { 2, 0, "Testing2", 0, 0, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TimeReports");
        }
    }
}
