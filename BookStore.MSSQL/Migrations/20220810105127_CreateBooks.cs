using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.MSSQL.Migrations
{
    public partial class CreateBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Date", "Title" },
                values: new object[,]
                {
                    { 1, "Толстой", "2022-08-10", "Война и мир" },
                    { 2, "Достоевский", "2022-08-09", "Преступление и наказание" },
                    { 3, "Булгаков", "2022-08-08", "Мастер и Маргарита" },
                    { 4, "Грибоедов", "2022-08-07", "Горе от ума" },
                    { 5, "Горький", "2022-08-06", "На дне" },
                    { 6, "Толстой", "2022-08-06", "Детство" },
                    { 7, "Булгаков", "2022-08-06", "Мастер и Маргарита" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
