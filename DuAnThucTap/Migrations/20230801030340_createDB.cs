using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DuAnThucTap.Migrations
{
    /// <inheritdoc />
    public partial class createDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name_Customer",
                table: "Tbl_Customer",
                newName: "Name_Customer");

            migrationBuilder.RenameColumn(
                name: "description_Customer",
                table: "Tbl_Customer",
                newName: "Description_Customer");

            migrationBuilder.RenameColumn(
                name: "age_Customer",
                table: "Tbl_Customer",
                newName: "Age_Customer");

            migrationBuilder.RenameColumn(
                name: "address_Customer",
                table: "Tbl_Customer",
                newName: "Address_Customer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name_Customer",
                table: "Tbl_Customer",
                newName: "name_Customer");

            migrationBuilder.RenameColumn(
                name: "Description_Customer",
                table: "Tbl_Customer",
                newName: "description_Customer");

            migrationBuilder.RenameColumn(
                name: "Age_Customer",
                table: "Tbl_Customer",
                newName: "age_Customer");

            migrationBuilder.RenameColumn(
                name: "Address_Customer",
                table: "Tbl_Customer",
                newName: "address_Customer");
        }
    }
}
