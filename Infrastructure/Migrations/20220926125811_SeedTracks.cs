using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class SeedTracks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Duration", "ImagePath", "Name", "Rating" },
                values: new object[] { 1, new TimeSpan(0, 0, 2, 45, 0), "images/1.jpg", "Yours JIN", 9.1f });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Duration", "ImagePath", "Name", "Rating" },
                values: new object[] { 2, new TimeSpan(0, 0, 4, 22, 0), "images/2.jpg", "Under The Influence", 8.5f });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "Duration", "ImagePath", "Name", "Rating" },
                values: new object[] { 3, new TimeSpan(0, 0, 3, 49, 0), "images/3.jpg", "I'm Good (Blue)", 8f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
