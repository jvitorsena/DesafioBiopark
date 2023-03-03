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
                    andar = table.Column<int>(type: "int", nullable: false),
                    alugado = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    edificiosId = table.Column<int>(type: "int", nullable: false)
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
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_bin");

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dtInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    valorAluguelMen = table.Column<double>(type: "double", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    isActive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    locatarioId = table.Column<int>(type: "int", nullable: false),
                    apartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contratos_Apartamentos_apartamentoId",
                        column: x => x.apartamentoId,
                        principalTable: "Apartamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Locatarios_locatarioId",
                        column: x => x.locatarioId,
                        principalTable: "Locatarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_bin");

            migrationBuilder.InsertData(
                table: "Edificios",
                columns: new[] { "id", "createdAt", "isActive", "locadora", "nome", "updatedAt" },
                values: new object[] { 1, new DateTime(2023, 3, 2, 22, 28, 59, 323, DateTimeKind.Local).AddTicks(7106), null, "Biopark", "Edificio primavera", new DateTime(2023, 3, 2, 22, 28, 59, 347, DateTimeKind.Local).AddTicks(176) });

            migrationBuilder.InsertData(
                table: "Locatarios",
                columns: new[] { "id", "createdAt", "dataNasc", "isActive", "primeiroNome", "segundoNome", "updatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(8247), new DateTime(1944, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Alexandre Levi", "Renato Baptista", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(8796) },
                    { 2, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9535), new DateTime(1944, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Alexandre Levi", "Renato Baptista", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9542) },
                    { 3, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9546), new DateTime(2002, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Liz", "Sônia Bernardes", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9547) },
                    { 4, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9551), new DateTime(1952, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Lucas", "Pietro Noah Moura", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9553) },
                    { 5, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9556), new DateTime(1962, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Elaine", "Natália Renata Souza", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9558) },
                    { 6, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9565), new DateTime(1945, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Elisa", "Bianca Porto", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9567) },
                    { 7, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9571), new DateTime(1978, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Francisca", "Isabelly Débora Rocha", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9572) },
                    { 8, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9575), new DateTime(1989, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Alexandre", "Bryan Nogueira", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9577) },
                    { 9, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9580), new DateTime(1982, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Nicole", "Analu Sarah Brito", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9582) },
                    { 10, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9586), new DateTime(1954, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Daiane", "Sabrina da Rosa", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9588) },
                    { 11, new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9591), new DateTime(1978, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Benício", "Manuel Lima", new DateTime(2023, 3, 2, 22, 28, 59, 348, DateTimeKind.Local).AddTicks(9592) }
                });

            migrationBuilder.InsertData(
                table: "Apartamentos",
                columns: new[] { "id", "alugado", "andar", "createdAt", "edificiosId", "isActive", "numero", "updatedAt" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(8027), 1, true, 101, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(8391) },
                    { 2, true, 1, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9072), 1, true, 102, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9079) },
                    { 3, true, 2, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9083), 1, true, 201, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9085) },
                    { 4, true, 2, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9088), 1, true, 202, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9090) },
                    { 5, true, 3, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9093), 1, true, 301, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9095) },
                    { 6, true, 3, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9102), 1, true, 302, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9104) },
                    { 7, true, 4, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9108), 1, true, 401, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9109) },
                    { 8, true, 4, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9112), 1, true, 402, new DateTime(2023, 3, 2, 22, 28, 59, 349, DateTimeKind.Local).AddTicks(9114) }
                });

            migrationBuilder.InsertData(
                table: "Contratos",
                columns: new[] { "id", "apartamentoId", "createdAt", "dtInicio", "isActive", "locatarioId", "updatedAt", "valorAluguelMen" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 2, 22, 28, 59, 350, DateTimeKind.Local).AddTicks(3681), new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, new DateTime(2023, 3, 2, 22, 28, 59, 350, DateTimeKind.Local).AddTicks(4059), 600.0 },
                    { 2, 5, new DateTime(2023, 3, 2, 22, 28, 59, 350, DateTimeKind.Local).AddTicks(5397), new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 5, new DateTime(2023, 3, 2, 22, 28, 59, 350, DateTimeKind.Local).AddTicks(5404), 600.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_edificiosId",
                table: "Apartamentos",
                column: "edificiosId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_apartamentoId",
                table: "Contratos",
                column: "apartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_locatarioId",
                table: "Contratos",
                column: "locatarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Locatarios");

            migrationBuilder.DropTable(
                name: "Edificios");
        }
    }
}
