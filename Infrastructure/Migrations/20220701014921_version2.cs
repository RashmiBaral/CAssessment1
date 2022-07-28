using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    RoleName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<string>(nullable: true),
                    UserDetailID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.RoleName);
                    table.ForeignKey(
                        name: "FK_UserRoles_UserDetails_UserDetailID",
                        column: x => x.UserDetailID,
                        principalTable: "UserDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserDetailID",
                table: "UserRoles",
                column: "UserDetailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");
        }
    }
}
