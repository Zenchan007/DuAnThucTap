using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DuAnThucTap.Migrations
{
    public partial class dbinit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Customer",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_Customer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    age_Customer = table.Column<int>(type: "int", nullable: false),
                    address_Customer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    description_Customer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Customer", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Customer");
        }
    }
}
