using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBCurso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Curso",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NivelDeDificuldadeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Curso_TBCategoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "TBCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Curso_TB_NivelDeDificuldade_NivelDeDificuldadeId",
                        column: x => x.NivelDeDificuldadeId,
                        principalTable: "TB_NivelDeDificuldade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etapas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etapas_TB_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "TB_Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etapas_CursoId",
                table: "Etapas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Curso_CategoriaId",
                table: "TB_Curso",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Curso_NivelDeDificuldadeId",
                table: "TB_Curso",
                column: "NivelDeDificuldadeId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Curso_Nome",
                table: "TB_Curso",
                column: "Nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etapas");

            migrationBuilder.DropTable(
                name: "TB_Curso");
        }
    }
}
