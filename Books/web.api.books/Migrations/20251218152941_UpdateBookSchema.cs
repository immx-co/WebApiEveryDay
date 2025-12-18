using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.api.books.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "Books",
                newName: "Updated");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Books",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Updated",
                table: "Books",
                newName: "Timestamp");
        }
    }
}
