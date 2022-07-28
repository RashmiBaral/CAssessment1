using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class version9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CaseStudyDetailsCSID",
                table: "CaseStudySolutions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Competency",
                columns: table => new
                {
                    CompId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Compname = table.Column<string>(nullable: true),
                    CaseStudyDetailsCSID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competency", x => x.CompId);
                    table.ForeignKey(
                        name: "FK_Competency_CaseStudyDetails_CaseStudyDetailsCSID",
                        column: x => x.CaseStudyDetailsCSID,
                        principalTable: "CaseStudyDetails",
                        principalColumn: "CSID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseStudySolutions_CaseStudyDetailsCSID",
                table: "CaseStudySolutions",
                column: "CaseStudyDetailsCSID");

            migrationBuilder.CreateIndex(
                name: "IX_Competency_CaseStudyDetailsCSID",
                table: "Competency",
                column: "CaseStudyDetailsCSID");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseStudySolutions_CaseStudyDetails_CaseStudyDetailsCSID",
                table: "CaseStudySolutions",
                column: "CaseStudyDetailsCSID",
                principalTable: "CaseStudyDetails",
                principalColumn: "CSID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseStudySolutions_CaseStudyDetails_CaseStudyDetailsCSID",
                table: "CaseStudySolutions");

            migrationBuilder.DropTable(
                name: "Competency");

            migrationBuilder.DropIndex(
                name: "IX_CaseStudySolutions_CaseStudyDetailsCSID",
                table: "CaseStudySolutions");

            migrationBuilder.DropColumn(
                name: "CaseStudyDetailsCSID",
                table: "CaseStudySolutions");
        }
    }
}
