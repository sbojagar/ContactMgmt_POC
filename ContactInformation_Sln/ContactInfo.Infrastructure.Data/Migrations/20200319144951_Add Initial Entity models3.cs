using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactInfo.Infrastructure.Data.Migrations
{
    public partial class AddInitialEntitymodels3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactServices_ContactGroupsGroupID",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactServices",
                table: "ContactServices");

            migrationBuilder.RenameTable(
                name: "ContactServices",
                newName: "ContactGroups");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactGroups",
                table: "ContactGroups",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactGroups_ContactGroupsGroupID",
                table: "Contacts",
                column: "ContactGroupsGroupID",
                principalTable: "ContactGroups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactGroups_ContactGroupsGroupID",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactGroups",
                table: "ContactGroups");

            migrationBuilder.RenameTable(
                name: "ContactGroups",
                newName: "ContactServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactServices",
                table: "ContactServices",
                column: "GroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactServices_ContactGroupsGroupID",
                table: "Contacts",
                column: "ContactGroupsGroupID",
                principalTable: "ContactServices",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
