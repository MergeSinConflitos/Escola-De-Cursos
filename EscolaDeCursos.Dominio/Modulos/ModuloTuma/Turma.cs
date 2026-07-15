using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloInstrutor;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

namespace EscolaDeCursos.Dominio.Modulos.ModuloTuma;

public class Turma : EntidadeBase<Turma>
{
    public string Nome { get; set; }
    public Periodo Periodo { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataTermino { get; set; }
    public int QuantidadeMaxAlunos { get; set; }
    public Curso Curso { get; set; }
    public Instrutor Instrutor { get; set; }
    public List<Matricula> Matriculas { get; set; } = new List<Matricula>();

    public Turma() { }

    public Turma(string nome,Periodo periodo, DateTime dataInicio, DateTime dataTermino, int quantidadeMaxAlunos, Curso curso, Instrutor instrutor)
    {
        Nome = nome;
        Periodo = periodo;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        QuantidadeMaxAlunos = quantidadeMaxAlunos;
        Curso = curso;
        Instrutor = instrutor;
    }

    public bool EstaCheia()
    {
        return (Matriculas?.Count ?? 0) >= QuantidadeMaxAlunos;
    }

    public bool PossuiMatriculas()  
    {
        return (Matriculas?.Count ?? 0) > 0;
    }
    public bool PodeSerExcluida(int totalMatriculasAtivas)
    {
        return totalMatriculasAtivas == 0;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" é obrigatório.");
        else if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (Periodo == 0)
            erros.Add("O período da turma é obrigatório.");

        if (DataInicio == default)
            erros.Add("O campo \"Data de Início\" é obrigatório.");

        if (DataTermino == default)
            erros.Add("O campo \"Data de Término\" é obrigatório.");
        else if (DataTermino <= DataInicio)
            erros.Add("A data de término deve ser posterior à data de início.");

        if (QuantidadeMaxAlunos <= 0)
            erros.Add("A quantidade máxima de alunos deve ser maior que zero.");

        if (Curso == null)
            erros.Add("O campo \"Curso\" é obrigatório.");

        if (Instrutor == null)
            erros.Add("O campo \"Instrutor\" é obrigatório.");

        return erros;
    }

    public override void Atualizar(Turma entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Periodo = entidadeAtualizada.Periodo;
        DataInicio = entidadeAtualizada.DataInicio;
        DataTermino = entidadeAtualizada.DataTermino;
        QuantidadeMaxAlunos = entidadeAtualizada.QuantidadeMaxAlunos;
        Curso = entidadeAtualizada.Curso;
        Instrutor = entidadeAtualizada.Instrutor;
    }
}