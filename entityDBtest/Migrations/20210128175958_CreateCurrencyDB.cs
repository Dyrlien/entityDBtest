using Microsoft.EntityFrameworkCore.Migrations;

namespace entityDBtest.Migrations
{
    public partial class CreateCurrencyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateString",
                columns: table => new
                {
                    Date = table.Column<string>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateString", x => x.Date);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    UpdatedDate = table.Column<string>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currency_DateString_UpdatedDate",
                        column: x => x.UpdatedDate,
                        principalTable: "DateString",
                        principalColumn: "Date",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Currency_UpdatedDate",
                table: "Currency",
                column: "UpdatedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "DateString");
        }
    }
}
