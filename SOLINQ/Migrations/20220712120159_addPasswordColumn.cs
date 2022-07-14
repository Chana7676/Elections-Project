using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elections.Migrations
{
    public partial class addPasswordColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "sex",
                table: "Voters",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Voters",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Voters");

            migrationBuilder.AlterColumn<string>(
                name: "sex",
                table: "Voters",
                type: "varchar(50)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
