using Microsoft.EntityFrameworkCore.Migrations;

namespace test2.Migrations
{
    public partial class text2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[] { 2, "KSD", "DKS", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 2);
        }
    }
}
