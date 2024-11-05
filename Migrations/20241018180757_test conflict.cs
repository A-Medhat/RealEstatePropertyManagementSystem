using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace realEstate1.Migrations
{
    /// <inheritdoc />
    public partial class testconflict : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leases_tenants_TenantID",
                table: "leases");

            migrationBuilder.AlterColumn<int>(
                name: "TenantID",
                table: "leases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_leases_tenants_TenantID",
                table: "leases",
                column: "TenantID",
                principalTable: "tenants",
                principalColumn: "TenantID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leases_tenants_TenantID",
                table: "leases");

            migrationBuilder.AlterColumn<int>(
                name: "TenantID",
                table: "leases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_leases_tenants_TenantID",
                table: "leases",
                column: "TenantID",
                principalTable: "tenants",
                principalColumn: "TenantID");
        }
    }
}
