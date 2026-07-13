using System;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public class NivelDeDificuldadeConfiguration : IEntityTypeConfiguration<NivelDeDificuldade>
{
    public void Configure(EntityTypeBuilder<NivelDeDificuldade> builder)
    {
        builder.ToTable("TB_NivelDeDificuldade");

        builder.HasKey(d => d.Id)
        .HasName("PK_TBNivelDeDificuldade");

        builder.Property(d => d.Id)
              .ValueGeneratedNever();

        builder.Property(d => d.Nome)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(d => d.Descricao)
               .HasMaxLength(255);

        builder.Property(d => d.Classificacao)
               .IsRequired();

    }
}
