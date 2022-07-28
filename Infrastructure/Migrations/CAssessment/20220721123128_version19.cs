using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.CAssessment
{
    public partial class version19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "selected",
                table: "UserDetails",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "selected",
                table: "UserDetails");
        }
    }
}
