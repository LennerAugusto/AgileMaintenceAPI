using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgileMaintenceAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Client_ClientId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_ClientId",
                table: "Adresses");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientEntityId",
                table: "Adresses",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ClientEntityId",
                table: "Adresses",
                column: "ClientEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Client_ClientEntityId",
                table: "Adresses",
                column: "ClientEntityId",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Client_ClientEntityId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_ClientEntityId",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "ClientEntityId",
                table: "Adresses");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ClientId",
                table: "Adresses",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Client_ClientId",
                table: "Adresses",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
