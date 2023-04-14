using Microsoft.EntityFrameworkCore.Migrations;

namespace WinkelApp.Migrations
{
    public partial class initialdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auteurs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phonenumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auteurs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Auteurid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_Auteurs_Auteurid",
                        column: x => x.Auteurid,
                        principalTable: "Auteurs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "id", "Email", "Firstname", "Lastname", "Phonenumber" },
                values: new object[] { 1, "HBersen@Winkel.nl", "Henk", "Bersen", 612459246 });

            migrationBuilder.InsertData(
                table: "Auteurs",
                columns: new[] { "id", "Email", "Firstname", "Lastname", "Phonenumber" },
                values: new object[] { 2, "LJansen@Winkel.nl", "Lisa", "Jansen", 651234943 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "Auteurid", "Description", "Name", "Price" },
                values: new object[] { 1, 1, "Een knuffel die er uitziet als een hond", "Honden knuffel", 10.0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "Auteurid", "Description", "Name", "Price" },
                values: new object[] { 2, 1, "Een knuffel die er uitziet als een kat", "Katten knuffel", 10.0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "id", "Auteurid", "Description", "Name", "Price" },
                values: new object[] { 3, 2, "Een kleine boot gemaakt van hout", "Houten boot", 15.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Items_Auteurid",
                table: "Items",
                column: "Auteurid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Auteurs");
        }
    }
}
