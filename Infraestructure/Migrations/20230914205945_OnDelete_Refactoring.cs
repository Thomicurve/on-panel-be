using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class OnDelete_Refactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_capital_user_UserId",
                table: "capital");

            migrationBuilder.DropForeignKey(
                name: "FK_cost_cost_type_CostTypeId",
                table: "cost");

            migrationBuilder.DropForeignKey(
                name: "FK_cost_user_UserId",
                table: "cost");

            migrationBuilder.DropForeignKey(
                name: "FK_product_user_UserId",
                table: "product");

            migrationBuilder.AddForeignKey(
                name: "FK_capital_user_UserId",
                table: "capital",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cost_cost_type_CostTypeId",
                table: "cost",
                column: "CostTypeId",
                principalTable: "cost_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cost_user_UserId",
                table: "cost",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_user_UserId",
                table: "product",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_capital_user_UserId",
                table: "capital");

            migrationBuilder.DropForeignKey(
                name: "FK_cost_cost_type_CostTypeId",
                table: "cost");

            migrationBuilder.DropForeignKey(
                name: "FK_cost_user_UserId",
                table: "cost");

            migrationBuilder.DropForeignKey(
                name: "FK_product_user_UserId",
                table: "product");

            migrationBuilder.AddForeignKey(
                name: "FK_capital_user_UserId",
                table: "capital",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cost_cost_type_CostTypeId",
                table: "cost",
                column: "CostTypeId",
                principalTable: "cost_type",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_cost_user_UserId",
                table: "cost",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_user_UserId",
                table: "product",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id");
        }
    }
}
