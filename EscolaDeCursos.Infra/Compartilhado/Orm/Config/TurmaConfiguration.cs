
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public class TurmaConfiguration : IEntityTypeConfiguration<Turma>
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
            .HasColumnType("int")
            .IsRequired();

        builder.Property(t => t.DataInicio)
            .HasColumnType("date")
            .IsRequired();

        
        builder.Property(t => t.DataTermino)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(t => t.QuantidadeMaxAlunos)
            .IsRequired();

        builder.HasOne(t => t.Curso)
            .WithMany()
            .HasForeignKey("CursoId")
            .IsRequired();
        
        builder.HasOne(t => t.Instrutor)
            .WithMany()
            .HasForeignKey("InstrutorId")
            .IsRequired();
    
        builder.HasMany(t => t.Matriculas)
            .WithOne(m => m.Turma)
            .HasForeignKey("TurmaId")
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}
