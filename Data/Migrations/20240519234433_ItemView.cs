using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITProjectTryThree.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailsItemViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemId = table.Column<int>(type: "int", nullable: false),
                    collectionid = table.Column<int>(type: "int", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    search = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsItemViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailsItemViewModel_Collections_collectionid",
                        column: x => x.collectionid,
                        principalTable: "Collections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailsItemViewModel_Items_itemId",
                        column: x => x.itemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EditItemViewModel",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThisItemId = table.Column<int>(type: "int", nullable: false),
                    ThisCollectionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditItemViewModel", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_EditItemViewModel_Collections_ThisCollectionid",
                        column: x => x.ThisCollectionid,
                        principalTable: "Collections",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EditItemViewModel_Items_ThisItemId",
                        column: x => x.ThisItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailsItemViewModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_DetailsItemViewModel_DetailsItemViewModelId",
                        column: x => x.DetailsItemViewModelId,
                        principalTable: "DetailsItemViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff38cac7-8b62-4594-9db1-5c4c328cf499", "c9e80112-6416-43ba-a69c-23665e777886" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_DetailsItemViewModelId",
                table: "Comments",
                column: "DetailsItemViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsItemViewModel_collectionid",
                table: "DetailsItemViewModel",
                column: "collectionid");

            migrationBuilder.CreateIndex(
                name: "IX_DetailsItemViewModel_itemId",
                table: "DetailsItemViewModel",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_EditItemViewModel_ThisCollectionid",
                table: "EditItemViewModel",
                column: "ThisCollectionid");

            migrationBuilder.CreateIndex(
                name: "IX_EditItemViewModel_ThisItemId",
                table: "EditItemViewModel",
                column: "ThisItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EditItemViewModel");

            migrationBuilder.DropTable(
                name: "DetailsItemViewModel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "007",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eb0facd3-a7c5-4085-ae89-177c980eeb39", "794413cd-f541-43a5-af6c-0059c46fde8b" });
        }
    }
}
