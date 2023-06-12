using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLeasing.Web.Migrations
{
    public partial class ImageAndPhotoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerPhoto",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "LesseePhoto",
                table: "Lessees");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Owners",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PhotoId",
                table: "Lessees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Lessees");

            migrationBuilder.AddColumn<string>(
                name: "OwnerPhoto",
                table: "Owners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LesseePhoto",
                table: "Lessees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
