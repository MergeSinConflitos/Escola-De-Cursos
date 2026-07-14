using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.Aplicacao.Modulos.ModuloEtapa;
using EscolaDeCursos.Aplicacao.Modulos.ModuloNivelDeDificuldade;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EscolaDeCursos.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddScoped<ServicoCategoria>();
        services.AddScoped<ServicoNivelDeDificuldade>();
        services.AddScoped<ServicoCurso>();
        services.AddScoped<ServicoEtapa>();
        services.AddScoped<ServicoAluno>();
    }
}
