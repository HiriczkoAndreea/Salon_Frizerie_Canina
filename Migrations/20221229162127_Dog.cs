using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Salon_Frizerie_Canina.Migrations
{
    public partial class Dog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Dog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_DogId",
                table: "Service",
                column: "DogID");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Dog_DogId",
                table: "Service",
                column: "DogId",
                principalTable: "Dog",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Dog_DogId",
                table: "Service");

            migrationBuilder.DropTable(
                name: "Dog");

            migrationBuilder.DropIndex(
                name: "IX_Service_DogId",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Service");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Service",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
