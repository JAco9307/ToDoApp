using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Todo.model.Migrations
{
    /// <inheritdoc />
    public partial class StatusSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TodoStatus",
                columns: new[] { "Id", "Order", "Title" },
                values: new object[,]
                {
                    { -3, 1, "Not Started" },
                    { -2, 2, "In Progress" },
                    { -1, 3, "Completed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TodoStatus",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "TodoStatus",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "TodoStatus",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
