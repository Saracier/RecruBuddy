using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruBuddy.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                        CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "JobOffers");
        }
    }
}
