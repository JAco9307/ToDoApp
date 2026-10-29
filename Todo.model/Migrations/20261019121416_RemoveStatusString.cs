using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.model.Migrations
{
    /// <inheritdoc />
    public partial class RemoveStatusString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoStatusOptions");

            migrationBuilder.DropColumn(
                name: "StatusString",
                table: "TodoItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StatusString",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TodoStatusOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    options = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoStatusOptions", x => x.Id);
                });
        }
    }
}
