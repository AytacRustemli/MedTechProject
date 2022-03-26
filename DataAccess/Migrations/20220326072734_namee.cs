using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class namee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Doctors_DoctorID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_DoctorID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_DoctorID",
                table: "Books",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Doctors_DoctorID",
                table: "Books",
                column: "DoctorID",
                principalTable: "Doctors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
