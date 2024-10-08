using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferGen.API.Migrations
{
    /// <inheritdoc />
    public partial class CLientModelAndConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferHeaders_Companies_CompanyId",
                table: "OfferHeaders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferHeaders",
                table: "OfferHeaders");

            migrationBuilder.RenameTable(
                name: "OfferHeaders",
                newName: "OfferHeader");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Companies",
                newName: "CompanyContactInfo_Phone");

            migrationBuilder.RenameColumn(
                name: "Email_EmailAddress",
                table: "Companies",
                newName: "CompanyContactInfo_EmailAddress");

            migrationBuilder.RenameColumn(
                name: "Address_ZIPCode",
                table: "Companies",
                newName: "CompanyAddress_ZIPCode");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Companies",
                newName: "CompanyAddress_Street");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Companies",
                newName: "CompanyAddress_City");

            migrationBuilder.RenameIndex(
                name: "IX_OfferHeaders_CompanyId",
                table: "OfferHeader",
                newName: "IX_OfferHeader_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "TaxIdentifier",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CompanyContactInfo_ContactPerson",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferHeader",
                table: "OfferHeader",
                column: "OfferHeaderId");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxIdentifier = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClientAddress_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientAddress_ZIPCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientContactInfo_EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientContactInfo_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientContactInfo_ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Company_RegistrationNumber",
                table: "Companies",
                column: "RegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Company_TaxIdentifier",
                table: "Companies",
                column: "TaxIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RegistrationNumber",
                table: "Clients",
                column: "RegistrationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TaxIdentifier",
                table: "Clients",
                column: "TaxIdentifier",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferHeader_Companies_CompanyId",
                table: "OfferHeader",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferHeader_Companies_CompanyId",
                table: "OfferHeader");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Company_RegistrationNumber",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Company_TaxIdentifier",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferHeader",
                table: "OfferHeader");

            migrationBuilder.DropColumn(
                name: "CompanyContactInfo_ContactPerson",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "OfferHeader",
                newName: "OfferHeaders");

            migrationBuilder.RenameColumn(
                name: "CompanyContactInfo_Phone",
                table: "Companies",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "CompanyContactInfo_EmailAddress",
                table: "Companies",
                newName: "Email_EmailAddress");

            migrationBuilder.RenameColumn(
                name: "CompanyAddress_ZIPCode",
                table: "Companies",
                newName: "Address_ZIPCode");

            migrationBuilder.RenameColumn(
                name: "CompanyAddress_Street",
                table: "Companies",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "CompanyAddress_City",
                table: "Companies",
                newName: "Address_City");

            migrationBuilder.RenameIndex(
                name: "IX_OfferHeader_CompanyId",
                table: "OfferHeaders",
                newName: "IX_OfferHeaders_CompanyId");

            migrationBuilder.AlterColumn<string>(
                name: "TaxIdentifier",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferHeaders",
                table: "OfferHeaders",
                column: "OfferHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferHeaders_Companies_CompanyId",
                table: "OfferHeaders",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
