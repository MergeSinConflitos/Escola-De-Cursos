using System;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.Dominio.Modulos.ModuloEtapa;

public class Etapa : EntidadeBase<Etapa> //modulo modulo
{
    public string Nome { get; set; }
    public int Duracao { get; set; }
    public int Ordem { get; set; }
    public Curso Curso { get; set; }
    public Etapa(string nome, int duracao, int ordem, Curso curso)
    {
        Nome = nome;
        Duracao = duracao;
        Ordem = ordem;
        Curso = curso;
    }
    public Etapa()
    {

    }
    public override void Atualizar(Etapa entidadeAtualizada)
    {
        Etapa etapaAtualizada = (Etapa)entidadeAtualizada;

        Nome = etapaAtualizada.Nome;
        Duracao = etapaAtualizada.Duracao;
        Ordem = etapaAtualizada.Ordem;
        Curso = etapaAtualizada.Curso;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
        {
            erros.Add("O campo \"Nome\"deve ser preenchido");
        }
        else if (Nome.Length < 2 || Nome.Length > 100)
        {
            erros.Add("O nome deve ter entre 2 e 100 caracteres");
        }

        if (Duracao <= 0)
        {
            erros.Add("Informe uma duração válida");
        }

        if (Ordem <= 0)
        {
            erros.Add("Informe uma ordem válida");
        }

        return erros;
    }
}
