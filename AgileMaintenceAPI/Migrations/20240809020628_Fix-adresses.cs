using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgileMaintenceAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fixadresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Adresses_AdressesId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AdressesId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AdressesId",
                table: "Clients");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_ClientId",
                table: "Adresses",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Clients_ClientId",
                table: "Adresses",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Clients_ClientId",
                table: "Adresses");

            migrationBuilder.DropIndex(
                name: "IX_Adresses_ClientId",
                table: "Adresses");

            migrationBuilder.AddColumn<Guid>(
                name: "AdressesId",
                table: "Clients",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdressesId",
                table: "Clients",
                column: "AdressesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Adresses_AdressesId",
                table: "Clients",
                column: "AdressesId",
                principalTable: "Adresses",
                principalColumn: "Id");
        }
    }
}
