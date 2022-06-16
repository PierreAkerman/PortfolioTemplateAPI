using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioTemplateAPI.Data.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgUrl",
                table: "Gallery",
                newName: "ImageUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Gallery",
                newName: "ImgUrl");
        }
    }
}
