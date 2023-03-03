using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DesafioBiopark.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.CreateTable(
                name: "Edificios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_bin")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    locadora = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_bin")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edificios", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_bin");

            migrationBuilder.CreateTable(
                name: "Locatarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    primeiroNome = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_bin")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    segundoNome = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb3_bin")
                        .Annotation("MySql:CharSet", "utf8mb3"),
                    dataNasc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatarios", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_bin");

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    numero = table.Column<int>(type: "int", nullable: false),
                    valorAluguelMens = table.Column<double>(type: "double", nullable: false),
                    andar = table.Column<int>(type: "int", nullable: false),
                    alugado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    edificiosId = table.Column<int>(type: "int", nullable: false),
                    locatariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Edificios_edificiosId",
                        column: x => x.edificiosId,
                        principalTable: "Edificios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Locatarios_locatariosId",
                        column: x => x.locatariosId,
                        principalTable: "Locatarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_bin");

            migrationBuilder.InsertData(
                table: "Edificios",
                columns: new[] { "id", "createdAt", "isActive", "locadora", "nome", "updatedAt" },
                values: new object[] { 1, new DateTime(2023, 3, 2, 20, 13, 56, 63, DateTimeKind.Local).AddTicks(3780), null, "Biopark", "Edificio primavera", new DateTime(2023, 3, 2, 20, 13, 56, 89, DateTimeKind.Local).AddTicks(7923) });

            migrationBuilder.InsertData(
                table: "Locatarios",
                columns: new[] { "id", "createdAt", "dataNasc", "isActive", "primeiroNome", "segundoNome", "updatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(7135), new DateTime(1944, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Alexandre Levi", "Renato Baptista", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(7504) },
                    { 2, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8249), new DateTime(1944, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Alexandre Levi", "Renato Baptista", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8257) },
                    { 3, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8262), new DateTime(2002, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Liz", "Sônia Bernardes", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8264) },
                    { 4, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8267), new DateTime(1952, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Lucas", "Pietro Noah Moura", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8269) },
                    { 5, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8271), new DateTime(1962, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Elaine", "Natália Renata Souza", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8273) },
                    { 6, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8281), new DateTime(1945, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Elisa", "Bianca Porto", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8283) },
                    { 7, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8286), new DateTime(1978, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Francisca", "Isabelly Débora Rocha", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8288) },
                    { 8, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8291), new DateTime(1989, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Alexandre", "Bryan Nogueira", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8292) },
                    { 9, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8295), new DateTime(1982, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nicole", "Analu Sarah Brito", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8296) },
                    { 10, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8301), new DateTime(1954, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Daiane", "Sabrina da Rosa", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8302) },
                    { 11, new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8305), new DateTime(1978, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Benício", "Manuel Lima", new DateTime(2023, 3, 2, 20, 13, 56, 91, DateTimeKind.Local).AddTicks(8306) }
                });

            migrationBuilder.InsertData(
                table: "Apartamentos",
                columns: new[] { "id", "alugado", "andar", "createdAt", "edificiosId", "isActive", "locatariosId", "numero", "updatedAt", "valorAluguelMens" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(7920), 1, true, 1, 101, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8286), 600.0 },
                    { 2, true, 1, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8941), 1, true, 2, 102, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8948), 600.0 },
                    { 3, true, 2, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8952), 1, true, 3, 201, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8955), 600.0 },
                    { 4, true, 2, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8958), 1, true, 4, 202, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8959), 600.0 },
                    { 5, true, 3, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8963), 1, true, 5, 301, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8964), 600.0 },
                    { 6, true, 3, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8971), 1, true, 6, 302, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8973), 600.0 },
                    { 7, true, 4, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8977), 1, true, 7, 401, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8979), 600.0 },
                    { 8, true, 4, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8982), 1, true, 8, 402, new DateTime(2023, 3, 2, 20, 13, 56, 92, DateTimeKind.Local).AddTicks(8984), 600.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_edificiosId",
                table: "Apartamentos",
                column: "edificiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_locatariosId",
                table: "Apartamentos",
                column: "locatariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Edificios");

            migrationBuilder.DropTable(
                name: "Locatarios");
        }
    }
}
