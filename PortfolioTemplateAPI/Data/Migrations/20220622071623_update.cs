using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTemplateAPI.Data.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Gallery",
                newName: "ImgUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Gallery",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Gallery",
                newName: "ImageUrl");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Gallery",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
