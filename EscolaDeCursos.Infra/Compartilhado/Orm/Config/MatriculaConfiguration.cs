using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
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
            .IsRequired();


        builder.HasOne(m => m.Aluno)
            .WithMany()
            .HasForeignKey("AlunoId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);


        builder.HasOne(m => m.Turma)
            .WithMany(t => t.Matriculas)
            .HasForeignKey("TurmaId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }

}