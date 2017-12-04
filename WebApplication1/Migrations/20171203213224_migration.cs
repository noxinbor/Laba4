using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "educators",
                columns: table => new
                {
                    educators_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nchar(10)", nullable: false),
                    Awards = table.Column<string>(type: "nchar(10)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    FIO = table.Column<string>(type: "nchar(10)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educators", x => x.educators_id);
                });

            migrationBuilder.CreateTable(
                name: "types_of_groups",
                columns: table => new
                {
                    Types_of_groups_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_types_of_groups", x => x.Types_of_groups_id);
                });

            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    groups_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    educators_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    number_of_children = table.Column<int>(type: "int", nullable: false),
                    types_of_groups_id = table.Column<int>(type: "int", nullable: false),
                    year_of_creation = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.groups_id);
                    table.ForeignKey(
                        name: "FK_groups_educators",
                        column: x => x.educators_id,
                        principalTable: "educators",
                        principalColumn: "educators_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_groups_types_of_groups",
                        column: x => x.types_of_groups_id,
                        principalTable: "types_of_groups",
                        principalColumn: "Types_of_groups_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pupils",
                columns: table => new
                {
                    pupils_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    attendance_group = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FIO_father = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FIO_mather = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    groups_id = table.Column<int>(type: "int", nullable: false),
                    info = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pupils", x => x.pupils_id);
                    table.ForeignKey(
                        name: "FK_pupils_groups",
                        column: x => x.groups_id,
                        principalTable: "groups",
                        principalColumn: "groups_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_groups_educators_id",
                table: "groups",
                column: "educators_id");

            migrationBuilder.CreateIndex(
                name: "IX_groups_types_of_groups_id",
                table: "groups",
                column: "types_of_groups_id");

            migrationBuilder.CreateIndex(
                name: "IX_pupils_groups_id",
                table: "pupils",
                column: "groups_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pupils");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "educators");

            migrationBuilder.DropTable(
                name: "types_of_groups");
        }
    }
}
