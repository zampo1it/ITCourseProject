using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class items : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollectionId = table.Column<int>(type: "int", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntCustom1 = table.Column<int>(type: "int", nullable: false),
                    IntCustom2 = table.Column<int>(type: "int", nullable: false),
                    IntCustom3 = table.Column<int>(type: "int", nullable: false),
                    StringCustom1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringCustom2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StringCustom3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoolCustom1 = table.Column<bool>(type: "bit", nullable: false),
                    BoolCustom2 = table.Column<bool>(type: "bit", nullable: false),
                    BoolCustom3 = table.Column<bool>(type: "bit", nullable: false),
                    DateCustom1 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCustom2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCustom3 = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eb0facd3-a7c5-4085-ae89-177c980eeb39", "794413cd-f541-43a5-af6c-0059c46fde8b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "73196d74-2bae-44fe-9d9c-5b414ac7a7f5", "77eea571-0344-44cb-adc0-529191515171" });
        }
    }
}
