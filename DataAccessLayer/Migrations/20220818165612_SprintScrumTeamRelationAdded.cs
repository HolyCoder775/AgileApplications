using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SprintScrumTeamRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sprints_ScrumTeamId",
                table: "Sprints",
                column: "ScrumTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_ScrumTeams_ScrumTeamId",
                table: "Sprints",
                column: "ScrumTeamId",
                principalTable: "ScrumTeams",
                principalColumn: "ScrumTeamId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_ScrumTeams_ScrumTeamId",
                table: "Sprints");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_ScrumTeamId",
                table: "Sprints");
        }
    }
}
