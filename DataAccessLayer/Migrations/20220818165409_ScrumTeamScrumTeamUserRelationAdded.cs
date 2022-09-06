using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ScrumTeamScrumTeamUserRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ScrumTeamUsers_ScrumTeamId",
                table: "ScrumTeamUsers",
                column: "ScrumTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScrumTeamUsers_ScrumTeams_ScrumTeamId",
                table: "ScrumTeamUsers",
                column: "ScrumTeamId",
                principalTable: "ScrumTeams",
                principalColumn: "ScrumTeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScrumTeamUsers_ScrumTeams_ScrumTeamId",
                table: "ScrumTeamUsers");

            migrationBuilder.DropIndex(
                name: "IX_ScrumTeamUsers_ScrumTeamId",
                table: "ScrumTeamUsers");
        }
    }
}
