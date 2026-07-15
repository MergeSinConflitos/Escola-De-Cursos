using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloTuma;

namespace EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

public class Matricula : EntidadeBase<Matricula>
{
    public DateTime DataInscricao { get; set; }
    public SituacaoMatricula Situacao { get; set; }
    public Aluno Aluno { get; set; } 
    public Turma Turma { get; set; } 

    public Matricula() { }

    public Matricula(Aluno aluno, Turma turma)
    {
        Aluno = aluno;
        Turma = turma;
        DataInscricao = DateTime.Now; 
        Situacao = SituacaoMatricula.Ativa;
    }

    public void Cancelar()
    {
        Situacao = SituacaoMatricula.Cancelada;
    }

    public void Concluir()
    {
        Situacao = SituacaoMatricula.Concluida;
    }

    public bool EstaAtiva()
    {
        return Situacao == SituacaoMatricula.Ativa;
    }

    public override void Atualizar(Matricula entidadeAtualizada)
    {
        Situacao = entidadeAtualizada.Situacao;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Aluno == null)
            erros.Add("O campo \"Aluno\" é obrigatório.");

        if (Turma == null)
            erros.Add("O campo \"Turma\" é obrigatório.");

        if (DataInscricao == default)
            erros.Add("O campo \"Data de Inscrição\" é obrigatório.");

        return erros;
    }
}
