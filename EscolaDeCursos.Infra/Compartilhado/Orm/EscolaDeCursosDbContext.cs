using System.Reflection;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloEtapa;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Compartilhado.Orm;

public sealed class EscolaDeCursosDbContext(
    DbContextOptions<EscolaDeCursosDbContext> options) : DbContext(options)
{

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<NivelDeDificuldade> NivelDeDificuldades => Set<NivelDeDificuldade>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Etapa> Etapas => Set<Etapa>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Turma> Turmas => Set<Turma>();
    public DbSet<Instrutor> Instrutores => Set<Instrutor>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly assembly = typeof(EscolaDeCursosDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}
