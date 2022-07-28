using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.CAssessment
{
    public partial class version22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Selected",
                table: "CaseStudyDetails",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Selected",
                table: "CaseStudyDetails");
        }
    }
}
