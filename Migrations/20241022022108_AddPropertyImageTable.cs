using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace realEstate1.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyImages_properties_PropertyID",
                table: "PropertyImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyImages",
                table: "PropertyImages");

            migrationBuilder.RenameTable(
                name: "PropertyImages",
                newName: "PropertiesImages");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyImages_PropertyID",
                table: "PropertiesImages",
                newName: "IX_PropertiesImages_PropertyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertiesImages",
                table: "PropertiesImages",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertiesImages_properties_PropertyID",
                table: "PropertiesImages",
                column: "PropertyID",
                principalTable: "properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertiesImages_properties_PropertyID",
                table: "PropertiesImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertiesImages",
                table: "PropertiesImages");

            migrationBuilder.RenameTable(
                name: "PropertiesImages",
                newName: "PropertyImages");

            migrationBuilder.RenameIndex(
                name: "IX_PropertiesImages_PropertyID",
                table: "PropertyImages",
                newName: "IX_PropertyImages_PropertyID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyImages",
                table: "PropertyImages",
                column: "ImageID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyImages_properties_PropertyID",
                table: "PropertyImages",
                column: "PropertyID",
                principalTable: "properties",
                principalColumn: "PropertyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
