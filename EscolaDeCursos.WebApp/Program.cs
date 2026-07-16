using EscolaDeCursos.Aplicacao;
using EscolaDeCursos.Infra;
using EscolaDeCursos.WebApp.Compartilhado;

var builder = WebApplication.CreateBuilder(args);

//coment
// Configuração do container de injeção de dependência

builder.Services.AddInfraRepositories(builder.Configuration, builder.Logging);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddPresentationConfig(builder.Configuration);


var app = builder.Build();



// Pipeline da aplicação

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.MapDefaultControllerRoute();


// Execução do Servidor

app.Run();