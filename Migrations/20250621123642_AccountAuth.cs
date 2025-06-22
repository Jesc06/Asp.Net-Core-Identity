using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.NetCore_Identity_Auth.Migrations
{
    /// <inheritdoc />
    public partial class AccountAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "fullname",
                table: "AspNetUsers",
                newName: "Fullname");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "AspNetUsers",
                newName: "fullname");
        }
    }
}
