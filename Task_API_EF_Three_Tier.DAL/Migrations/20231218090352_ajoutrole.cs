using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_API_EF_Three_Tier.DAL.Migrations
{
    public partial class ajoutrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "People");
        }
    }
}
