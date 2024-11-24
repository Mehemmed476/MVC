using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurpleBuzz.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatedOurServicesTableAndMakeOnetoManyRelationOurServiceToWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OurServiceId",
                table: "Works",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OurServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OurServices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Works_OurServiceId",
                table: "Works",
                column: "OurServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_OurServices_OurServiceId",
                table: "Works",
                column: "OurServiceId",
                principalTable: "OurServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_OurServices_OurServiceId",
                table: "Works");

            migrationBuilder.DropTable(
                name: "OurServices");

            migrationBuilder.DropIndex(
                name: "IX_Works_OurServiceId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "OurServiceId",
                table: "Works");
        }
    }
}
