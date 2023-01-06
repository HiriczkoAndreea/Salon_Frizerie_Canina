using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Frizerie_Canina.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "Dog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dog_CustomerID",
                table: "Dog",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Customer_CustomerID",
                table: "Dog",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Customer_CustomerID",
                table: "Dog");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Dog_CustomerID",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Dog");
        }
    }
}
