using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_appuser_coutry_gender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_workLocations_WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "WorkLocationID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_workLocations_WorkLocationID",
                table: "AspNetUsers",
                column: "WorkLocationID",
                principalTable: "workLocations",
                principalColumn: "WorkLocationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_workLocations_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "WorkLocationID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WorkLocationID1",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationID1",
                table: "AspNetUsers",
                column: "WorkLocationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_workLocations_WorkLocationID1",
                table: "AspNetUsers",
                column: "WorkLocationID1",
                principalTable: "workLocations",
                principalColumn: "WorkLocationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
