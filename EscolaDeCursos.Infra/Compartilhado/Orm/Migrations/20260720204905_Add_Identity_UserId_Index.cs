using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_Identity_UserId_Index : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBInstrutor_Cpf",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "IX_TBInstrutor_Email",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "IX_TBCategoria_Nome",
                table: "TBCategoria");

            migrationBuilder.DropIndex(
                name: "IX_TBAluno_Email",
                table: "TBAluno");

            migrationBuilder.DropIndex(
                name: "IX_TB_Curso_Nome",
                table: "TB_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_TBInstrutor_UserId_Cpf",
                table: "TBInstrutor",
                columns: new[] { "UserId", "Cpf" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBInstrutor_UserId_Email",
                table: "TBInstrutor",
                columns: new[] { "UserId", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBCategoria_UserId_Nome",
                table: "TBCategoria",
                columns: new[] { "UserId", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBAluno_UserId_Email",
                table: "TBAluno",
                columns: new[] { "UserId", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_NivelDeDificuldade_UserId_Nome",
                table: "TB_NivelDeDificuldade",
                columns: new[] { "UserId", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Etapa_UserId_Ordem",
                table: "TB_Etapa",
                columns: new[] { "UserId", "Ordem" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Curso_UserId_Nome",
                table: "TB_Curso",
                columns: new[] { "UserId", "Nome" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBInstrutor_UserId_Cpf",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "IX_TBInstrutor_UserId_Email",
                table: "TBInstrutor");

            migrationBuilder.DropIndex(
                name: "IX_TBCategoria_UserId_Nome",
                table: "TBCategoria");

            migrationBuilder.DropIndex(
                name: "IX_TBAluno_UserId_Email",
                table: "TBAluno");

            migrationBuilder.DropIndex(
                name: "IX_TB_NivelDeDificuldade_UserId_Nome",
                table: "TB_NivelDeDificuldade");

            migrationBuilder.DropIndex(
                name: "IX_TB_Etapa_UserId_Ordem",
                table: "TB_Etapa");

            migrationBuilder.DropIndex(
                name: "IX_TB_Curso_UserId_Nome",
                table: "TB_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_TBInstrutor_Cpf",
                table: "TBInstrutor",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBInstrutor_Email",
                table: "TBInstrutor",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBCategoria_Nome",
                table: "TBCategoria",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBAluno_Email",
                table: "TBAluno",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Curso_Nome",
                table: "TB_Curso",
                column: "Nome",
                unique: true);
        }
    }
}
