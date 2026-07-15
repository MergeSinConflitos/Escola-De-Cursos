
using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloEtapa;
using EscolaDeCursos.Aplicacao.Modulos.ModuloInstrutor;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTurma;


namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaProfile : Profile
{
    public TurmaProfile()
    {
        
        CreateMap<OpcaoCursoDto, OpcaoCursoViewModel>();
        CreateMap<OpcaoInstrutorDto, OpcaoInstrutorViewModel>();
        CreateMap<ListarTurmasDto, ListarTurmaViewModel>();
        CreateMap<CadastrarTurmaViewModel, CadastrarTurmaDto>();
        CreateMap<EditarTurmaViewModel, EditarTurmaDto>();

        CreateMap<DetalhesTurmaDto, EditarTurmaViewModel>()
            .ForCtorParam("Cursos", opt => opt.MapFrom(_ => new List<OpcaoCursoViewModel>()))
            .ForCtorParam("Instrutores", opt => opt.MapFrom(_ => new List<OpcaoInstrutorViewModel>()));

        CreateMap<DetalhesTurmaDto, ExcluirTurmaViewModel>();
        CreateMap<DetalhesTurmaDto, DetalhesTurmaViewModel>();
        CreateMap<AlunoMatriculadoDto, AlunoMatriculadoViewModel>();
    }
}