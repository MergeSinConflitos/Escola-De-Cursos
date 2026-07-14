using System;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public sealed class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("TB_Curso");

        builder.HasKey(c => c.Id)
              .HasName("PK_TBCurso");

        builder.Property(c => c.Id)
        .ValueGeneratedNever();

        builder.Property(c => c.Nome)
              .IsRequired()
              .HasMaxLength(100);

        builder.Property(c => c.CargaHoraria)
              .IsRequired();

        builder.HasIndex(c => c.Nome)
              .IsUnique();

        builder.HasOne(c => c.Categoria)
              .WithMany();

        builder.HasOne(c => c.NivelDeDificuldade)
              .WithMany();

        builder.HasMany(c => c.Etapas)
              .WithOne(e => e.Curso);
    }
}
