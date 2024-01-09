using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DungeonsAndDragons.Battle.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    HealthPoints = table.Column<int>(type: "integer", nullable: false),
                    AttackModifier = table.Column<int>(type: "integer", nullable: false),
                    AttackPerRound = table.Column<int>(type: "integer", nullable: false),
                    DamageCubesNumber = table.Column<int>(type: "integer", nullable: false),
                    DamageCubeCost = table.Column<int>(type: "integer", nullable: false),
                    DamageModifier = table.Column<int>(type: "integer", nullable: false),
                    ArmorClass = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Monsters",
                columns: new[] { "Id", "ArmorClass", "AttackModifier", "AttackPerRound", "DamageCubeCost", "DamageCubesNumber", "DamageModifier", "HealthPoints", "Name" },
                values: new object[,]
                {
                    { new Guid("0274631e-f105-42c0-ae95-857957f94565"), 12, 0, 10, 8, 7, 4, 100, "Asharra" },
                    { new Guid("3581e7f6-f453-4799-b59f-c784ca3d2156"), 7, 2, 10, 8, 3, 0, 40, "Lemure" },
                    { new Guid("5249c3b4-6afa-4c95-b5a7-702402a7688c"), 10, -3, 4, 4, 1, 1, 15, "Badger" },
                    { new Guid("b1c58c88-b3c7-4ade-a3d4-df8e6da449f4"), 10, 0, 10, 8, 2, 0, 70, "Devil Dog" },
                    { new Guid("c784cfcd-9d38-4207-83bf-1fe0e11f0526"), 19, 6, 23, 12, 17, 85, 200, "Adult black dragon" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_Id",
                table: "Monsters",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monsters");
        }
    }
}
