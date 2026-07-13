using System;
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoProfile : Profile
{
    public CursoProfile()
    {
        CreateMap<OpcaoCategoriaDto, OpcaoCategoriaViewModel>();
        CreateMap<OpcaoNivelDeDificuldadeDto, OpcaoNivelDeDificuldadeViewModel>();

        CreateMap<ListarCursosDto, ListarCursosViewModel>();

        CreateMap<CadastrarCursoViewModel, CadastrarCursoDto>();

        CreateMap<EditarCursoViewModel, EditarCursoDto>();

        CreateMap<DetalhesCursoDto, EditarCursoViewModel>()
            .ForCtorParam("Categorias", opt => opt.MapFrom(_ => new List<OpcaoCategoriaViewModel>()))
            .ForCtorParam("NiveisDeDificuldade", opt => opt.MapFrom(_ => new List<OpcaoNivelDeDificuldadeViewModel>()));

        CreateMap<DetalhesCursoDto, ExcluirCursoViewModel>();
    }
}
