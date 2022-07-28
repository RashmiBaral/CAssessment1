using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class version10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competency_CaseStudyDetails_CaseStudyDetailsCSID",
                table: "Competency");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Competency",
                table: "Competency");

            migrationBuilder.RenameTable(
                name: "Competency",
                newName: "CompetencyInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Competency_CaseStudyDetailsCSID",
                table: "CompetencyInfo",
                newName: "IX_CompetencyInfo_CaseStudyDetailsCSID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetencyInfo",
                table: "CompetencyInfo",
                column: "CompId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetencyInfo_CaseStudyDetails_CaseStudyDetailsCSID",
                table: "CompetencyInfo",
                column: "CaseStudyDetailsCSID",
                principalTable: "CaseStudyDetails",
                principalColumn: "CSID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetencyInfo_CaseStudyDetails_CaseStudyDetailsCSID",
                table: "CompetencyInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetencyInfo",
                table: "CompetencyInfo");

            migrationBuilder.RenameTable(
                name: "CompetencyInfo",
                newName: "Competency");

            migrationBuilder.RenameIndex(
                name: "IX_CompetencyInfo_CaseStudyDetailsCSID",
                table: "Competency",
                newName: "IX_Competency_CaseStudyDetailsCSID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Competency",
                table: "Competency",
                column: "CompId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competency_CaseStudyDetails_CaseStudyDetailsCSID",
                table: "Competency",
                column: "CaseStudyDetailsCSID",
                principalTable: "CaseStudyDetails",
                principalColumn: "CSID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
