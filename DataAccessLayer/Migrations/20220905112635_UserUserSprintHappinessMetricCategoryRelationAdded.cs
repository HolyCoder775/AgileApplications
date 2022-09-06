using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UserUserSprintHappinessMetricCategoryRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserSprintHappinessMetricCategories_UserId",
                table: "UserSprintHappinessMetricCategories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_Users_UserId",
                table: "UserSprintHappinessMetricCategories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_Users_UserId",
                table: "UserSprintHappinessMetricCategories");

            migrationBuilder.DropIndex(
                name: "IX_UserSprintHappinessMetricCategories_UserId",
                table: "UserSprintHappinessMetricCategories");
        }
    }
}
