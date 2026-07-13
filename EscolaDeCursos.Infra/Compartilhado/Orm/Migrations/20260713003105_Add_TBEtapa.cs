using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBEtapa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etapas_TB_Curso_CursoId",
                table: "Etapas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Etapas",
                table: "Etapas");

            migrationBuilder.RenameTable(
                name: "Etapas",
                newName: "TB_Etapa");

            migrationBuilder.RenameIndex(
                name: "IX_Etapas_CursoId",
                table: "TB_Etapa",
                newName: "IX_TB_Etapa_CursoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_Etapa",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBEtapa",
                table: "TB_Etapa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_Etapa_TB_Curso_CursoId",
                table: "TB_Etapa",
                column: "CursoId",
                principalTable: "TB_Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_Etapa_TB_Curso_CursoId",
                table: "TB_Etapa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBEtapa",
                table: "TB_Etapa");

            migrationBuilder.RenameTable(
                name: "TB_Etapa",
                newName: "Etapas");

            migrationBuilder.RenameIndex(
                name: "IX_TB_Etapa_CursoId",
                table: "Etapas",
                newName: "IX_Etapas_CursoId");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Etapas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Etapas",
                table: "Etapas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Etapas_TB_Curso_CursoId",
                table: "Etapas",
                column: "CursoId",
                principalTable: "TB_Curso",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
