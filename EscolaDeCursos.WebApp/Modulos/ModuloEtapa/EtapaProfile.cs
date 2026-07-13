using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloEtapa;

namespace EscolaDeCursos.WebApp.Modulos.ModuloEtapa;

public class EtapaProfile : Profile
{
    public EtapaProfile()
    {
        CreateMap<ListarEtapasDto, ListarEtapasViewModel>();

        CreateMap<CadastrarEtapaViewModel, CadastrarEtapaDto>();

        CreateMap<EditarEtapaViewModel, EditarEtapaDto>();

        CreateMap<DetalhesEtapaDto, EditarEtapaViewModel>()
            .ForCtorParam(
                "Cursos",
                opt => opt.MapFrom(_ => new List<OpcaoCursoViewModel>())
            );

        CreateMap<DetalhesEtapaDto, ExcluirEtapaViewModel>();

        CreateMap<OpcaoCursoDto, OpcaoCursoViewModel>();
    }
}
