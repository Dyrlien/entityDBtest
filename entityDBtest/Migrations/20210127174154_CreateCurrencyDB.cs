using Microsoft.EntityFrameworkCore.Migrations;

namespace entityDBtest.Migrations
{
    public partial class CreateCurrencyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Date = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Date);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
