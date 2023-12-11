using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_API_EF_Three_Tier.DAL.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonEntity",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEntity", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "TaskEntity",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskEntity", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "TaskPersonEntity",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskPersonEntity", x => new { x.TaskId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_TaskPersonEntity_PersonEntity_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonEntity",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskPersonEntity_TaskEntity_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TaskEntity",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskPersonEntity_PersonId",
                table: "TaskPersonEntity",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskPersonEntity");

            migrationBuilder.DropTable(
                name: "PersonEntity");

            migrationBuilder.DropTable(
                name: "TaskEntity");
        }
    }
}
