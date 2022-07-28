using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.CAssessment
{
    public partial class version18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentDetail",
                columns: table => new
                {
                    AssessmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentName = table.Column<string>(type: "varchar(100)", nullable: true),
                    AssmtDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentDetail", x => x.AssessmentID);
                });

            migrationBuilder.CreateTable(
                name: "CaseStudyDetails",
                columns: table => new
                {
                    CSID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseStudy = table.Column<string>(type: "varchar(100)", nullable: true),
                    AssessmentID = table.Column<int>(type: "int", nullable: false),
                    ReviewStatus = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStudyDetails", x => x.CSID);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    EmpID = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    PasswordChangeDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CaseStudySolutions",
                columns: table => new
                {
                    CSSID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Solution = table.Column<string>(type: "varchar(100)", nullable: true),
                    CSID = table.Column<int>(type: "int", nullable: false),
                    CompetencyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStudySolutions", x => x.CSSID);
                    table.ForeignKey(
                        name: "FK_CaseStudySolutions_CaseStudyDetails_CSID",
                        column: x => x.CSID,
                        principalTable: "CaseStudyDetails",
                        principalColumn: "CSID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompetencyInfo",
                columns: table => new
                {
                    CompId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compname = table.Column<string>(nullable: true),
                    CaseStudyDetailsCSID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetencyInfo", x => x.CompId);
                    table.ForeignKey(
                        name: "FK_CompetencyInfo_CaseStudyDetails_CaseStudyDetailsCSID",
                        column: x => x.CaseStudyDetailsCSID,
                        principalTable: "CaseStudyDetails",
                        principalColumn: "CSID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    UserDetailID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_UserRoles_UserDetails_UserDetailID",
                        column: x => x.UserDetailID,
                        principalTable: "UserDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseStudySolutions_CSID",
                table: "CaseStudySolutions",
                column: "CSID");

            migrationBuilder.CreateIndex(
                name: "IX_CompetencyInfo_CaseStudyDetailsCSID",
                table: "CompetencyInfo",
                column: "CaseStudyDetailsCSID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserDetailID",
                table: "UserRoles",
                column: "UserDetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentDetail");

            migrationBuilder.DropTable(
                name: "CaseStudySolutions");

            migrationBuilder.DropTable(
                name: "CompetencyInfo");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "CaseStudyDetails");

            migrationBuilder.DropTable(
                name: "UserDetails");
        }
    }
}
