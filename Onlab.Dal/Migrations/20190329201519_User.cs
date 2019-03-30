using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onlab.Dal.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_UserId1",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_UserId1",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Albums",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Albums_UserId",
                table: "Albums",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_UserId",
                table: "Albums",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_UserId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_UserId",
                table: "Albums");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Albums",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Albums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_UserId1",
                table: "Albums",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_UserId1",
                table: "Albums",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
