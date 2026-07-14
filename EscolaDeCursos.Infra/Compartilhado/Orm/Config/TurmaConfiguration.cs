using EscolaDeCursos.Dominio.Modulos.ModuloTuma;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public sealed class TurmaConfiguration : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("TBTurma");

        builder.HasKey(t => t.Id)
            .HasName("PK_TBTurma");

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.Property(t => t.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Periodo)
            .IsRequired();

        builder.Property(t => t.DataInicio)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(t => t.DataTermino)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(t => t.QuantidadeMaxAlunos)
            .IsRequired();


        // Toda turma deve possuir exatamente um curso
        builder.HasOne(t => t.Curso)
            .WithMany()
            .HasForeignKey("CursoId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        // Toda turma deve possuir exatamente um instrutor
        builder.HasOne(t => t.Instrutor)
            .WithMany()
            .HasForeignKey("InstrutorId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        // Uma turma possui várias matrículas
        builder.HasMany(t => t.Matriculas)
            .WithOne(m => m.Turma)
            .HasForeignKey("TurmaId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}