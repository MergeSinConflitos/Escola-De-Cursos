using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBMatricula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_TBAluno_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_TBTurma_TurmaId",
                table: "Matriculas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas");

            migrationBuilder.RenameTable(
                name: "Matriculas",
                newName: "TBMatricula");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_TurmaId",
                table: "TBMatricula",
                newName: "IX_TBMatricula_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_Matriculas_AlunoId",
                table: "TBMatricula",
                newName: "IX_TBMatricula_AlunoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInscricao",
                table: "TBMatricula",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TBMatricula",
                table: "TBMatricula",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBMatricula_TBAluno_AlunoId",
                table: "TBMatricula",
                column: "AlunoId",
                principalTable: "TBAluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBMatricula_TBTurma_TurmaId",
                table: "TBMatricula",
                column: "TurmaId",
                principalTable: "TBTurma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBMatricula_TBAluno_AlunoId",
                table: "TBMatricula");

            migrationBuilder.DropForeignKey(
                name: "FK_TBMatricula_TBTurma_TurmaId",
                table: "TBMatricula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TBMatricula",
                table: "TBMatricula");

            migrationBuilder.RenameTable(
                name: "TBMatricula",
                newName: "Matriculas");

            migrationBuilder.RenameIndex(
                name: "IX_TBMatricula_TurmaId",
                table: "Matriculas",
                newName: "IX_Matriculas_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_TBMatricula_AlunoId",
                table: "Matriculas",
                newName: "IX_Matriculas_AlunoId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInscricao",
                table: "Matriculas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matriculas",
                table: "Matriculas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_TBAluno_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "TBAluno",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_TBTurma_TurmaId",
                table: "Matriculas",
                column: "TurmaId",
                principalTable: "TBTurma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
