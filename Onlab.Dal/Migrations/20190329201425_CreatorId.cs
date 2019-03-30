using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Onlab.Dal.Migrations
{
    public partial class CreatorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_CreatorId1",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_CreatorId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CreatorId1",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Albums_CreatorId1",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreatorId1",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Images",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "CreatorId",
                table: "Albums",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Images_CreatorId",
                table: "Images",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_CreatorId",
                table: "Albums",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_CreatorId",
                table: "Albums",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_CreatorId",
                table: "Images",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_CreatorId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_CreatorId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CreatorId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Albums_CreatorId",
                table: "Albums");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Images",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Images",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Albums",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorId1",
                table: "Albums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_CreatorId1",
                table: "Images",
                column: "CreatorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_CreatorId1",
                table: "Albums",
                column: "CreatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_CreatorId1",
                table: "Albums",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_CreatorId1",
                table: "Images",
                column: "CreatorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
