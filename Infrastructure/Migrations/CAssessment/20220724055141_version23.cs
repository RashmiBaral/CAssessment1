using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.CAssessment
{
    public partial class version23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentCaseStudyMap",
                columns: table => new
                {
                    ASCID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssmtID = table.Column<int>(nullable: false),
                    CSID = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentCaseStudyMap", x => x.ASCID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentCaseStudyMap");
        }
    }
}
