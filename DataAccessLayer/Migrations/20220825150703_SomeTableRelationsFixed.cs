using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SomeTableRelationsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_HappinessMetricCategories_HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories");

            migrationBuilder.AlterColumn<int>(
                name: "HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_HappinessMetricCategories_HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories",
                column: "HappinessMetricCategoryId",
                principalTable: "HappinessMetricCategories",
                principalColumn: "HappinessMetricCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_HappinessMetricCategories_HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories");

            migrationBuilder.AlterColumn<int>(
                name: "HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSprintHappinessMetricCategories_HappinessMetricCategories_HappinessMetricCategoryId",
                table: "UserSprintHappinessMetricCategories",
                column: "HappinessMetricCategoryId",
                principalTable: "HappinessMetricCategories",
                principalColumn: "HappinessMetricCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
