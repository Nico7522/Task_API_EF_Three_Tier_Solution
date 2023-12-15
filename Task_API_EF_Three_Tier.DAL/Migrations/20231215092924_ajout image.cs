using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_API_EF_Three_Tier.DAL.Migrations
{
    public partial class ajoutimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "People",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "/avatardefault.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "People");
        }
    }
}
