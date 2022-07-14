using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elections.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "varchar(100)", nullable: false),
                    image = table.Column<string>(type: "varchar(200)", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(100)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(20)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(20)", nullable: false),
                    sex = table.Column<string>(type: "varchar(50)", nullable: false),
                    city = table.Column<string>(type: "varchar(50)", nullable: false),
                    party_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.id);
                    table.ForeignKey(
                        name: "FK_Voters_Parties_party_id",
                        column: x => x.party_id,
                        principalTable: "Parties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voters_party_id",
                table: "Voters",
                column: "party_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}
