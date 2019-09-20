using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkModule.Migrations
{
    public partial class init9201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentTests_StudentTestId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Students_StudentTestId",
                table: "Student",
                newName: "IX_Student_StudentTestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SystemMenus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(maxLength: 1, nullable: false),
                    Remark = table.Column<string>(maxLength: 128, nullable: true),
                    AddTime = table.Column<DateTime>(maxLength: 23, nullable: false),
                    ParentMenuId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
                    IconUrl = table.Column<string>(maxLength: 128, nullable: true),
                    LinkUrl = table.Column<string>(maxLength: 128, nullable: true),
                    Sort = table.Column<int>(maxLength: 10, nullable: false),
                    Permission = table.Column<string>(maxLength: 256, nullable: true),
                    IsDisplay = table.Column<bool>(maxLength: 1, nullable: false),
                    IsSystem = table.Column<bool>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemMenus_SystemMenus_ParentMenuId",
                        column: x => x.ParentMenuId,
                        principalTable: "SystemMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(maxLength: 1, nullable: false),
                    Remark = table.Column<string>(maxLength: 128, nullable: true),
                    AddTime = table.Column<DateTime>(maxLength: 23, nullable: false),
                    RoleName = table.Column<string>(maxLength: 64, nullable: false),
                    RoleType = table.Column<int>(maxLength: 10, nullable: false),
                    IsSystem = table.Column<bool>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(maxLength: 1, nullable: false),
                    Remark = table.Column<string>(maxLength: 128, nullable: true),
                    AddTime = table.Column<DateTime>(maxLength: 23, nullable: false),
                    UserName = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    Avatar = table.Column<string>(maxLength: 256, nullable: true),
                    NickName = table.Column<string>(maxLength: 32, nullable: true),
                    Mobile = table.Column<string>(maxLength: 16, nullable: true),
                    Email = table.Column<string>(maxLength: 128, nullable: true),
                    LoginCount = table.Column<int>(maxLength: 10, nullable: false),
                    LoginLastIp = table.Column<string>(maxLength: 64, nullable: true),
                    LoginLastTime = table.Column<DateTime>(maxLength: 23, nullable: false),
                    IsLock = table.Column<bool>(maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(maxLength: 1, nullable: false),
                    Remark = table.Column<string>(maxLength: 128, nullable: true),
                    AddTime = table.Column<DateTime>(maxLength: 23, nullable: false),
                    SystemMenusId = table.Column<string>(nullable: true),
                    SystemRolesId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleMenus_SystemMenus_SystemMenusId",
                        column: x => x.SystemMenusId,
                        principalTable: "SystemMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleMenus_SystemRoles_SystemRolesId",
                        column: x => x.SystemRolesId,
                        principalTable: "SystemRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDelete = table.Column<bool>(maxLength: 1, nullable: false),
                    Remark = table.Column<string>(maxLength: 128, nullable: true),
                    AddTime = table.Column<DateTime>(maxLength: 23, nullable: false),
                    UserAccountId = table.Column<string>(nullable: true),
                    SystemRoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_SystemRoles_SystemRoleId",
                        column: x => x.SystemRoleId,
                        principalTable: "SystemRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_SystemUsers_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "SystemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_SystemMenusId",
                table: "RoleMenus",
                column: "SystemMenusId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenus_SystemRolesId",
                table: "RoleMenus",
                column: "SystemRolesId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemMenus_ParentMenuId",
                table: "SystemMenus",
                column: "ParentMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_SystemRoleId",
                table: "UserRoles",
                column: "SystemRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserAccountId",
                table: "UserRoles",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_StudentTests_StudentTestId",
                table: "Student",
                column: "StudentTestId",
                principalTable: "StudentTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_StudentTests_StudentTestId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "RoleMenus");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "SystemMenus");

            migrationBuilder.DropTable(
                name: "SystemRoles");

            migrationBuilder.DropTable(
                name: "SystemUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Student_StudentTestId",
                table: "Students",
                newName: "IX_Students_StudentTestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentTests_StudentTestId",
                table: "Students",
                column: "StudentTestId",
                principalTable: "StudentTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
