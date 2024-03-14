using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace As.Park.Model.Migrations
{
    /// <inheritdoc />
    public partial class MigrationMoreRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Plates_CarId",
                table: "Plates");

            migrationBuilder.DropColumn(
                name: "Plate",
                table: "Vignettes");

            migrationBuilder.DropColumn(
                name: "Car",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "Plate",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Vignettes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Fines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FineDate",
                table: "Fines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Fines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Fines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlateId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vignettes_CarId",
                table: "Vignettes",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Plates_CarId",
                table: "Plates",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fines_CarId",
                table: "Fines",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_OwnerId",
                table: "Fines",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_UserId",
                table: "Fines",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Cars_CarId",
                table: "Fines",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Owners_OwnerId",
                table: "Fines",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Fines_Users_UserId",
                table: "Fines",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vignettes_Cars_CarId",
                table: "Vignettes",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Cars_CarId",
                table: "Fines");

            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Owners_OwnerId",
                table: "Fines");

            migrationBuilder.DropForeignKey(
                name: "FK_Fines_Users_UserId",
                table: "Fines");

            migrationBuilder.DropForeignKey(
                name: "FK_Vignettes_Cars_CarId",
                table: "Vignettes");

            migrationBuilder.DropIndex(
                name: "IX_Vignettes_CarId",
                table: "Vignettes");

            migrationBuilder.DropIndex(
                name: "IX_Plates_CarId",
                table: "Plates");

            migrationBuilder.DropIndex(
                name: "IX_Fines_CarId",
                table: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Fines_OwnerId",
                table: "Fines");

            migrationBuilder.DropIndex(
                name: "IX_Fines_UserId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Vignettes");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "FineDate",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Fines");

            migrationBuilder.DropColumn(
                name: "PlateId",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Plate",
                table: "Vignettes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Car",
                table: "Fines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Fines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Fines",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Plate",
                table: "Cars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Plates_CarId",
                table: "Plates",
                column: "CarId");
        }
    }
}
