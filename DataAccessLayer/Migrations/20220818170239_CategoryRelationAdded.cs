using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CategoryRelationAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSprintHappinessMetricCategories_HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories",
                column: "HappinessMetricCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_HappinessMetricCategories_HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories",
                column: "HappinessMetricCategoryId",
                principalTable: "HappinessMetricCategories",
                principalColumn: "HappinessMetricCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_HappinessMetricCategories_HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories");

            migrationBuilder.DropIndex(
                name: "IX_UserSprintHappinessMetricCategories_HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories");

            migrationBuilder.DropColumn(
                name: "HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories");
        }
    }
}
