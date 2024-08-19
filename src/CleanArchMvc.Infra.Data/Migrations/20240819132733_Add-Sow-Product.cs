using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CleanArchMvc.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSowProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Papel A4", "", "Papel", 10m, 1 },
                    { 2, 1, "Caneta bic", "", "Caneta", 2m, 10 },
                    { 3, 1, "Lápis Faber Castel", "", "Lápis", 4m, 10 },
                    { 4, 2, "Celular A12", "", "Celular", 1200m, 10 },
                    { 5, 2, "Tv 32 polegadas Samsung", "", "Tv Smart", 2500m, 10 },
                    { 6, 2, "Notebook Avell liv62", "", "Notebook", 9870m, 10 },
                    { 7, 3, "Bolsa de couro legítimo", "", "Bolsa", 500m, 1 },
                    { 8, 3, "Necessary padrão", "", "Necessary", 150m, 10 },
                    { 9, 3, "Pasta térmica", "", "Pasta", 22m, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
