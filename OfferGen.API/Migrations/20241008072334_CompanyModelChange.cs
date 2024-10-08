using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OfferGen.API.Migrations
{
    /// <inheritdoc />
    public partial class CompanyModelChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OfferHeaders_CompanyId",
                table: "OfferHeaders");

            migrationBuilder.CreateIndex(
                name: "IX_OfferHeaders_CompanyId",
                table: "OfferHeaders",
                column: "CompanyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OfferHeaders_CompanyId",
                table: "OfferHeaders");

            migrationBuilder.CreateIndex(
                name: "IX_OfferHeaders_CompanyId",
                table: "OfferHeaders",
                column: "CompanyId");
        }
    }
}
