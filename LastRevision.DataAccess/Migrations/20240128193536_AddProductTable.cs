using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LastRevision.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(511)",
                maxLength: 511,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "MicelAnglo", "I try do inter any data", "8000Aa961211", 63.0, "Nemo" },
                    { 2, "MicelAnglo", "I try do inter any data", "8000Aa961211", 62.0, "ToyStory" },
                    { 3, "MicelAnglo", "I try do inter any data", "8000Aa961211", 87.0, "Tangle" },
                    { 4, "MicelAnglo", "I try do inter any data", "8000Aa961211", 16.0, "Snowite" },
                    { 5, "MicelAnglo", "I try do inter any data", "8000Aa961211", 80.0, "Fola" },
                    { 6, "MicelAnglo", "I try do inter any data", "8000Aa961211", 40.0, "mongel" },
                    { 7, "MicelAnglo", "I try do inter any data", "8000Aa961211", 78.0, "Trazan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(511)",
                oldMaxLength: 511);
        }
    }
}
