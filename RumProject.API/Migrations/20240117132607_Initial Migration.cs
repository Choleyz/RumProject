using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RumProject.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distilleries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Bottler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistilleryImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distilleries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provenances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvenanceImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provenances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alcohols",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlcoholDegree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YearOfDistillation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YearOfBottling = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlcoholImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DistilleryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvenanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alcohols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alcohols_Distilleries_DistilleryId",
                        column: x => x.DistilleryId,
                        principalTable: "Distilleries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alcohols_Provenances_ProvenanceId",
                        column: x => x.ProvenanceId,
                        principalTable: "Provenances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alcohols_DistilleryId",
                table: "Alcohols",
                column: "DistilleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Alcohols_ProvenanceId",
                table: "Alcohols",
                column: "ProvenanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alcohols");

            migrationBuilder.DropTable(
                name: "Distilleries");

            migrationBuilder.DropTable(
                name: "Provenances");
        }
    }
}
