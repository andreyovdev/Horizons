using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horizons.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoritesCount",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Destinations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1276b01d-a473-4f85-8c1f-96902e371afa", "AQAAAAIAAYagAAAAEIKCMav18p7XhhZYe8Y+1AlCx9NGdeOD7Pug2943SozPcFiAJTdrWVc6XMGgb83aUA==", "101f3f88-67ed-44f6-bf13-9290a4e035bb" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2025, 2, 2, 23, 17, 11, 944, DateTimeKind.Local).AddTicks(3441));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2025, 2, 2, 23, 17, 11, 944, DateTimeKind.Local).AddTicks(3481));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2025, 2, 2, 23, 17, 11, 944, DateTimeKind.Local).AddTicks(3484));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavoritesCount",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Count of the times the destination got favorited");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Destinations",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is destiantion added to favorites");

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
                columns: new[] { "FavoritesCount", "IsFavorite", "PublishedOn" },
                values: new object[] { 0, false, new DateTime(2024, 12, 10, 11, 56, 26, 52, DateTimeKind.Local).AddTicks(1108) });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FavoritesCount", "IsFavorite", "PublishedOn" },
                values: new object[] { 0, false, new DateTime(2024, 12, 10, 11, 56, 26, 52, DateTimeKind.Local).AddTicks(1151) });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FavoritesCount", "IsFavorite", "PublishedOn" },
                values: new object[] { 0, false, new DateTime(2024, 12, 10, 11, 56, 26, 52, DateTimeKind.Local).AddTicks(1154) });
        }
    }
}
