using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_API_EF_Three_Tier.DAL.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskPersonEntity_PersonEntity_PersonId",
                table: "TaskPersonEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPersonEntity_TaskEntity_TaskId",
                table: "TaskPersonEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskPersonEntity",
                table: "TaskPersonEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskEntity",
                table: "TaskEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonEntity",
                table: "PersonEntity");

            migrationBuilder.RenameTable(
                name: "TaskPersonEntity",
                newName: "TaskPerson");

            migrationBuilder.RenameTable(
                name: "TaskEntity",
                newName: "Tasks");

            migrationBuilder.RenameTable(
                name: "PersonEntity",
                newName: "People");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPersonEntity_PersonId",
                table: "TaskPerson",
                newName: "IX_TaskPerson_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskPerson",
                table: "TaskPerson",
                columns: new[] { "TaskId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPerson_People_PersonId",
                table: "TaskPerson",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPerson_Tasks_TaskId",
                table: "TaskPerson",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskPerson_People_PersonId",
                table: "TaskPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskPerson_Tasks_TaskId",
                table: "TaskPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskPerson",
                table: "TaskPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TaskEntity");

            migrationBuilder.RenameTable(
                name: "TaskPerson",
                newName: "TaskPersonEntity");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "PersonEntity");

            migrationBuilder.RenameIndex(
                name: "IX_TaskPerson_PersonId",
                table: "TaskPersonEntity",
                newName: "IX_TaskPersonEntity_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskEntity",
                table: "TaskEntity",
                column: "TaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskPersonEntity",
                table: "TaskPersonEntity",
                columns: new[] { "TaskId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonEntity",
                table: "PersonEntity",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPersonEntity_PersonEntity_PersonId",
                table: "TaskPersonEntity",
                column: "PersonId",
                principalTable: "PersonEntity",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskPersonEntity_TaskEntity_TaskId",
                table: "TaskPersonEntity",
                column: "TaskId",
                principalTable: "TaskEntity",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
