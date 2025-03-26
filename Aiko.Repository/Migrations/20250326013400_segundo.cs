using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aiko.Repository.Migrations
{
    /// <inheritdoc />
    public partial class segundo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Custumer" },
                values: new object[] { 1, "BigCo" });

            migrationBuilder.InsertData(
                table: "Plays",
                columns: new[] { "PlayId", "Lines", "Nome", "Type" },
                values: new object[,]
                {
                    { 1, 4024, "Hamlet", "tragedy" },
                    { 2, 2670, "As You Like It", "comedy" },
                    { 3, 3560, "Othello", "tragedy" }
                });

            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "PerformanceId", "Audience", "InvoiceId", "PlayId" },
                values: new object[,]
                {
                    { 1, 55, 1, 1 },
                    { 2, 35, 1, 2 },
                    { 3, 40, 1, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "PerformanceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "PerformanceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "PerformanceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "PlayId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "PlayId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "PlayId",
                keyValue: 3);
        }
    }
}
