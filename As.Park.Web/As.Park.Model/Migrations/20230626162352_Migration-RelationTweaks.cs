using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace As.Park.Model.Migrations
{
    /// <inheritdoc />
    public partial class MigrationRelationTweaks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerName",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Plates_CarId",
                table: "Plates",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plates_Cars_CarId",
                table: "Plates",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plates_Cars_CarId",
                table: "Plates");

            migrationBuilder.DropIndex(
                name: "IX_Plates_CarId",
                table: "Plates");

            migrationBuilder.DropColumn(
                name: "OwnerName",
                table: "Cars");
        }
    }
}
