using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Todo.model.Migrations
{
    /// <inheritdoc />
    public partial class AddedTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoItemTodoTag",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TodoItemId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItemTodoTag", x => new { x.TagsId, x.TodoItemId });
                    table.ForeignKey(
                        name: "FK_TodoItemTodoTag_TodoItems_TodoItemId",
                        column: x => x.TodoItemId,
                        principalTable: "TodoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TodoItemTodoTag_TodoTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "TodoTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TodoTags",
                columns: new[] { "Id", "Color", "Title" },
                values: new object[,]
                {
                    { -3, -16776961, "Other" },
                    { -2, -256, "Important" },
                    { -1, -65536, "Urgent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItemTodoTag_TodoItemId",
                table: "TodoItemTodoTag",
                column: "TodoItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoItemTodoTag");

            migrationBuilder.DropTable(
                name: "TodoTags");
        }
    }
}
