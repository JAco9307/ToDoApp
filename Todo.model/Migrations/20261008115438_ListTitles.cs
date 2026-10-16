using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.model.Migrations
{
    /// <inheritdoc />
    public partial class ListTitles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TodoLists",
                type: "TEXT",
                nullable: false,
                defaultValue: "New List");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "TodoLists");
        }
    }
}
