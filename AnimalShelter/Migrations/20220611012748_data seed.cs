using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "DateAdd", "Gender", "Name", "Neutered", "Species" },
                values: new object[,]
                {
                    { 6, 7, new DateTime(2022, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Matilda", "Y", "Dog" },
                    { 2, 10, new DateTime(2022, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Rexie", "Y", "Dog" },
                    { 3, 2, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Female", "Matilda", "N", "Cat" },
                    { 4, 4, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Pip", "Y", "Bird" },
                    { 5, 22, new DateTime(2022, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Bartholomew", "N", "Cat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6);
        }
    }
}
