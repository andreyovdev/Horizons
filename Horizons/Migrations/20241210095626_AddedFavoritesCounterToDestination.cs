using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horizons.Migrations
{
    /// <inheritdoc />
    public partial class AddedFavoritesCounterToDestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoritesCount",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Count of the times the destination got favorited");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "966a38c6-4a9c-42ef-9df8-96df0d6335eb", "AQAAAAIAAYagAAAAED6ocgmsuW+fh7ohAHzs623by8gu0Ga8j0B108VCs5asVi0MVVRb4XZinOv6Kx7vxw==", "b48eb475-0d7f-4ad6-8f91-8904b9ca89e0" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FavoritesCount", "PublishedOn" },
                values: new object[] { 0, new DateTime(2024, 12, 10, 11, 56, 26, 52, DateTimeKind.Local).AddTicks(1108) });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FavoritesCount", "PublishedOn" },
                values: new object[] { 0, new DateTime(2024, 12, 10, 11, 56, 26, 52, DateTimeKind.Local).AddTicks(1151) });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FavoritesCount", "PublishedOn" },
                values: new object[] { 0, new DateTime(2024, 12, 10, 11, 56, 26, 52, DateTimeKind.Local).AddTicks(1154) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoritesCount",
                table: "Destinations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcd75164-dda1-4d0a-8ac5-0c7ed59857f4", "AQAAAAIAAYagAAAAEBTYFuNjGBRna7S8LMN6f9EqA00xSjiJMzjJYr5w3eZJJ949kn6wkBkbwZKnCDQE6A==", "302e5db5-696c-43a0-8aad-56e071ca1f22" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 10, 11, 26, 58, 726, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 10, 11, 26, 58, 726, DateTimeKind.Local).AddTicks(4006));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2024, 12, 10, 11, 26, 58, 726, DateTimeKind.Local).AddTicks(4009));
        }
    }
}
