using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PatientManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddDataTOPatientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "patients",
                columns: new[] { "Id", "Address", "DateOfBirth", "Email", "Gender", "PatientName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "burhanpur", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ashish@gmail.com", "Male", "ashish", "8319577873459" },
                    { 2, "indoer", new DateTime(2022, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "anshul@gmail.com", "female", "anshul", "8319232873459" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "patients",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
