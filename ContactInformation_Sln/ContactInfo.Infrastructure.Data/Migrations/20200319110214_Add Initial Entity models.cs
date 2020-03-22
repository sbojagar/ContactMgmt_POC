using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactInfo.Infrastructure.Data.Migrations
{
    public partial class AddInitialEntitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Contacts",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactServicesServiceID",
                table: "Contacts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ContactServices",
                columns: table => new
                {
                    ServiceID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactServices", x => x.ServiceID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ContactServicesServiceID",
                table: "Contacts",
                column: "ContactServicesServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_ContactServices_ContactServicesServiceID",
                table: "Contacts",
                column: "ContactServicesServiceID",
                principalTable: "ContactServices",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_ContactServices_ContactServicesServiceID",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactServices");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_ContactServicesServiceID",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactServicesServiceID",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Contacts",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
