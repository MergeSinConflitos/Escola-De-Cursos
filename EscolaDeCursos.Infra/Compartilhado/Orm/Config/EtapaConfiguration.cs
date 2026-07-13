using System;
using EscolaDeCursos.Dominio.Modulos.ModuloEtapa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public sealed class EtapaConfiguration : IEntityTypeConfiguration<Etapa>
{
    public void Configure(EntityTypeBuilder<Etapa> builder)
    {
        builder.ToTable("TB_Etapa");

        builder.HasKey(e => e.Id)
        .HasName("PK_TBEtapa");

        builder.Property(e => e.Id)
        .ValueGeneratedNever();

        builder.Property(e => e.Nome)
           .IsRequired()
           .HasMaxLength(100);

        builder.Property(e => e.Duracao)
               .IsRequired();

        builder.Property(e => e.Ordem)
               .IsRequired();

        builder.HasOne(e => e.Curso)
               .WithMany(c => c.Etapas);

    }
}
