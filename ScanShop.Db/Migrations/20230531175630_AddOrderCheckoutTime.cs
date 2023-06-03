using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScanShop.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderCheckoutTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutTime",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckoutTime",
                table: "Orders");
        }
    }
}
