using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UserScrumTeamUserRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ScrumTeamUsers_UserId",
                table: "ScrumTeamUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScrumTeamUsers_Users_UserId",
                table: "ScrumTeamUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScrumTeamUsers_Users_UserId",
                table: "ScrumTeamUsers");

            migrationBuilder.DropIndex(
                name: "IX_ScrumTeamUsers_UserId",
                table: "ScrumTeamUsers");
        }
    }
}
