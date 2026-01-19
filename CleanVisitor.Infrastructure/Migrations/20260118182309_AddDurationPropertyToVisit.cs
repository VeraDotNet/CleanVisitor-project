using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanVisitor.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDurationPropertyToVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "duration",
                table: "Visits",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duration",
                table: "Visits");
        }
    }
}
