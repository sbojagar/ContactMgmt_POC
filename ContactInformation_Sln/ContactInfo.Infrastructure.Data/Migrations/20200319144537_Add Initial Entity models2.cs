using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactInfo.Infrastructure.Data.Migrations
{
    public partial class AddInitialEntitymodels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactServices_ContactServicesServiceID",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "ServiceName",
                table: "ContactServices",
                newName: "GroupName");

            migrationBuilder.RenameColumn(
                name: "ServiceID",
                table: "ContactServices",
                newName: "GroupID");

            migrationBuilder.RenameColumn(
                name: "ContactServicesServiceID",
                table: "Contacts",
                newName: "ContactGroupsGroupID");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_ContactServicesServiceID",
                table: "Contacts",
                newName: "IX_Contacts_ContactGroupsGroupID");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Contacts",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactServices_ContactGroupsGroupID",
                table: "Contacts",
                column: "ContactGroupsGroupID",
                principalTable: "ContactServices",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactServices_ContactGroupsGroupID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "ContactServices",
                newName: "ServiceName");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "ContactServices",
                newName: "ServiceID");

            migrationBuilder.RenameColumn(
                name: "ContactGroupsGroupID",
                table: "Contacts",
                newName: "ContactServicesServiceID");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_ContactGroupsGroupID",
                table: "Contacts",
                newName: "IX_Contacts_ContactServicesServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactServices_ContactServicesServiceID",
                table: "Contacts",
                column: "ContactServicesServiceID",
                principalTable: "ContactServices",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
