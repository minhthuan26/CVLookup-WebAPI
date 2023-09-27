using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CVLookup_WebAPI.Migrations
{
    public partial class Edit_AccountUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountUser_Account_AccountID",
                table: "AccountUser");

            migrationBuilder.RenameColumn(
                name: "AccountID",
                table: "AccountUser",
                newName: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUser_Account_AccountId",
                table: "AccountUser",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountUser_Account_AccountId",
                table: "AccountUser");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AccountUser",
                newName: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountUser_Account_AccountID",
                table: "AccountUser",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
