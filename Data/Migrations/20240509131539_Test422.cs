using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class Test422 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73196d74-2bae-44fe-9d9c-5b414ac7a7f5", "77eea571-0344-44cb-adc0-529191515171" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "85754b71-0be4-4dfe-b5d0-bf3c5c3893c6", "289fbe70-62a8-4454-af69-d277154d42ee" });
        }
    }
}
