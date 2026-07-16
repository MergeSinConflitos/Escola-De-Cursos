using System.Reflection;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloEtapa;
using EscolaDeCursos.Dominio.Modulos.ModuloInstituicao;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;
using EscolaDeCursos.Dominio.Modulos.ModuloTuma;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Compartilhado.Orm;

public sealed class EscolaDeCursosDbContext(
    DbContextOptions<EscolaDeCursosDbContext> options
) : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<NivelDeDificuldade> NivelDeDificuldades => Set<NivelDeDificuldade>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Etapa> Etapas => Set<Etapa>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Instrutor> Instrutors => Set<Instrutor>();
    public DbSet<Turma> Turmas => Set<Turma>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Instituicao> Instituicaos => Set<Instituicao>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Assembly assembly = typeof(EscolaDeCursosDbContext).Assembly;


        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
