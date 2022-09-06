using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SprintUserSprintHappinessMetricCategoryRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserSprintHappinessMetricCategories_SprintId",
                table: "UserSprintHappinessMetricCategories",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_Sprints_SprintId",
                table: "UserSprintHappinessMetricCategories",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "SprintId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_Sprints_SprintId",
                table: "UserSprintHappinessMetricCategories");

            migrationBuilder.DropIndex(
                name: "IX_UserSprintHappinessMetricCategories_SprintId",
                table: "UserSprintHappinessMetricCategories");
        }
    }
}
