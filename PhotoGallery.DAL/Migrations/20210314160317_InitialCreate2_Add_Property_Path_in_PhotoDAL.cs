using Microsoft.EntityFrameworkCore.Migrations;

namespace PhotoGallery.DAL.Migrations
{
    public partial class InitialCreate2_Add_Property_Path_in_PhotoDAL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "Photos");
        }
    }
}
