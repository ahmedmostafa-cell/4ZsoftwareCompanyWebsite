using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbClients",
                columns: table => new
                {
                    ClentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientImageName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ClientWebiteLink = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbClients", x => x.ClentId);
                });

            migrationBuilder.CreateTable(
                name: "TbEmployees",
                columns: table => new
                {
                    EmplyeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmplyeeName = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    EmployeeJob = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    EmployeeLinkedInLink = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbEmployees", x => x.EmplyeeId);
                });

            migrationBuilder.CreateTable(
                name: "TbTestimonials",
                columns: table => new
                {
                    TestimonialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestimonialComment = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    TestimonialCommenter = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    TestimonialCommenterImage = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTestimonials", x => x.TestimonialId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbClients");

            migrationBuilder.DropTable(
                name: "TbEmployees");

            migrationBuilder.DropTable(
                name: "TbTestimonials");
        }
    }
}
