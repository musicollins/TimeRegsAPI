using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeRegApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjectName = table.Column<string>(type: "TEXT", nullable: false),
                    Company = table.Column<string>(type: "TEXT", nullable: false),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GitHub = table.Column<string>(type: "TEXT", nullable: false),
                    Aktiv = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    TimeReportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EducationHours = table.Column<int>(type: "INTEGER", nullable: false),
                    PreperationHours = table.Column<int>(type: "INTEGER", nullable: false),
                    Other = table.Column<int>(type: "INTEGER", nullable: false),
                    AfterHours = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.TimeReportId);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeReports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[] { 1, "Test@test.se", "Filip", "Lindberg", "112233", 112 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[] { 2, "Test2@test.se", "Andre", "Lindqvist", "332211", 112 });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Aktiv", "Company", "Deadline", "GitHub", "ProjectName" },
                values: new object[] { 1, true, "Aveer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Länk", "Test" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Aktiv", "Company", "Deadline", "GitHub", "ProjectName" },
                values: new object[] { 2, false, "Aveer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Länk 2", "Testing" });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportId", "AfterHours", "Comment", "EducationHours", "EmployeeId", "Other", "PreperationHours", "ProjectId" },
                values: new object[] { 1, 2, "Testing", 0, 1, 0, 0, 2 });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "TimeReportId", "AfterHours", "Comment", "EducationHours", "EmployeeId", "Other", "PreperationHours", "ProjectId" },
                values: new object[] { 2, 0, "Testing2", 0, 2, 0, 5, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
