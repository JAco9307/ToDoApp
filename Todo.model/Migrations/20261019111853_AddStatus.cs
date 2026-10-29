using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.model.Migrations
{
    /// <inheritdoc />
    public partial class AddStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "TodoItems",
                newName: "StatusString");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "TodoItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TodoStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_StatusId",
                table: "TodoItems",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoStatus_StatusId",
                table: "TodoItems",
                column: "StatusId",
                principalTable: "TodoStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoStatus_StatusId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "TodoStatus");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_StatusId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "StatusString",
                table: "TodoItems",
                newName: "Status");
        }
    }
}
