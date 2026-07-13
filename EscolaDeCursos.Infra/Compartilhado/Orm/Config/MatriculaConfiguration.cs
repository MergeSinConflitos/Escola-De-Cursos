using System;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("TBMatricula");

        builder.HasKey(m => m.Id)
            .HasName("PK_TBMatricula");

        builder.Property(m => m.Id)
            .ValueGeneratedNever();

        builder.Property(m => m.DataInscricao)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(m => m.Situacao)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(m => m.Aluno)
            .WithMany()
            .HasForeignKey("AlunoId")
            .IsRequired();

        builder.HasOne(m => m.Turma)
            .WithMany(t => t.Matriculas)
            .HasForeignKey("TurmaId")
            .IsRequired();
    }
}
