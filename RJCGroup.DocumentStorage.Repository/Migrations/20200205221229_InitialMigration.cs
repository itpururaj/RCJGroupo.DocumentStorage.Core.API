using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RJCGroup.DocumentStorage.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    FileSize = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Order = table.Column<int>(nullable: false),
                    DocumentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DocumentId = table.Column<Guid>(nullable: false),
                    Content = table.Column<byte[]>(nullable: false),
                    UploadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentContent_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentContent_DocumentId",
                table: "DocumentContent",
                column: "DocumentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentContent");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
