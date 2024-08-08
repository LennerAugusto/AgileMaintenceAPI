using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgileMaintenceAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixOrderServiceClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Clients_ClientId1",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_ClientId1",
                table: "OrderServices");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "OrderServices");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "OrderServices",
                type: "char(36)",
                nullable: false,
                collation: "ascii_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_ClientId",
                table: "OrderServices",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Clients_ClientId",
                table: "OrderServices",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderServices_Clients_ClientId",
                table: "OrderServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderServices_ClientId",
                table: "OrderServices");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "OrderServices",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId1",
                table: "OrderServices",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_OrderServices_ClientId1",
                table: "OrderServices",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderServices_Clients_ClientId1",
                table: "OrderServices",
                column: "ClientId1",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
