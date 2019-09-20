using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkModule.Migrations
{
    public partial class init920 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "StudentTests",
                maxLength: 23,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "StudentTests",
                maxLength: 1,
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "StudentTests",
                maxLength: 128,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(maxLength: 1, nullable: false),
                    Remark = table.Column<string>(maxLength: 128, nullable: true),
                    AddTime = table.Column<DateTime>(maxLength: 23, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    StudentTestId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_StudentTests_StudentTestId",
                        column: x => x.StudentTestId,
                        principalTable: "StudentTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentTestId",
                table: "Students",
                column: "StudentTestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "StudentTests");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "StudentTests");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "StudentTests");
        }
    }
}
