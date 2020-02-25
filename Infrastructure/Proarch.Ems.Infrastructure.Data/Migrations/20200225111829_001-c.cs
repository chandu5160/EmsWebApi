using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proarch.Ems.Infrastructure.Data.Migrations
{
    public partial class _001c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ems_client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ems_client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ems_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ems_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ems_Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ems_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ems_Project_Ems_client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Ems_client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ems_Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ems_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ems_Employee_Ems_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Ems_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ems_Employee_Ems_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Ems_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ems_UserStory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IsRecurring = table.Column<bool>(nullable: false),
                    DefaultHours = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ems_UserStory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ems_UserStory_Ems_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Ems_Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ems_UserStory_Ems_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Ems_Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ems_TaskTime",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    UserStoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ems_TaskTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ems_TaskTime_Ems_UserStory_UserStoryId",
                        column: x => x.UserStoryId,
                        principalTable: "Ems_UserStory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ems_Employee_EmployeeId",
                table: "Ems_Employee",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ems_Employee_ProjectId",
                table: "Ems_Employee",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ems_Employee_RoleId",
                table: "Ems_Employee",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ems_Project_ClientId",
                table: "Ems_Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ems_TaskTime_UserStoryId",
                table: "Ems_TaskTime",
                column: "UserStoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ems_UserStory_EmployeeId",
                table: "Ems_UserStory",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ems_UserStory_ProjectId",
                table: "Ems_UserStory",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ems_TaskTime");

            migrationBuilder.DropTable(
                name: "Ems_UserStory");

            migrationBuilder.DropTable(
                name: "Ems_Employee");

            migrationBuilder.DropTable(
                name: "Ems_Project");

            migrationBuilder.DropTable(
                name: "Ems_Role");

            migrationBuilder.DropTable(
                name: "Ems_client");
        }
    }
}
