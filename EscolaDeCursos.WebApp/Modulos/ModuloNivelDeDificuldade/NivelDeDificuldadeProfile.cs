using System;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloNivelDeDificuldade;

namespace EscolaDeCursos.WebApp.Modulos.ModuloNivelDeDificuldade;

public class NivelDeDificuldadeProfile : Profile
{
    public NivelDeDificuldadeProfile()
    {
        CreateMap<ListarNivelDeDificuldadeDto, ListarNivelDeDificuldadeViewModel>();
        CreateMap<CadastrarNivelDeDificuldadeViewModel, CadastrarNivelDeDificuldadeDto>();
        CreateMap<EditarNivelDeDificuldadeViewModel, EditarNivelDeDificuldadeDto>();
        CreateMap<DetalhesNivelDeDificuldadeDto, EditarNivelDeDificuldadeViewModel>();
        CreateMap<DetalhesNivelDeDificuldadeDto, ExcluirNivelDeDificuldadeViewModel>();
    }
}
