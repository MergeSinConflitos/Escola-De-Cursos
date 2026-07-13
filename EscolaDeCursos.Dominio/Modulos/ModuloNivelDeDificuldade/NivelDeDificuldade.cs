using System;
using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;

public enum Classificacao
{
    Basico,
    Intermediario,
    Avancado,
    Especializado
}
public class NivelDeDificuldade : EntidadeBase<NivelDeDificuldade>
{
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public Classificacao? Classificacao { get; set; }

    public NivelDeDificuldade(string nome, string? descricao, Classificacao classificacao)
    {
        Nome = nome;
        Descricao = descricao;
        Classificacao = classificacao;
    }
    public NivelDeDificuldade()
    {

    }
    public override void Atualizar(NivelDeDificuldade entidadeAtualizada)
    {
        NivelDeDificuldade nivelDeDificuldadeAtualizado = (NivelDeDificuldade)entidadeAtualizada;

        Nome = nivelDeDificuldadeAtualizado.Nome;
        Descricao = nivelDeDificuldadeAtualizado.Descricao;
        Classificacao = nivelDeDificuldadeAtualizado.Classificacao;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
        {
            erros.Add("O campo \"Nome\"deve ser preenchido");
        }
        else if (Nome.Length < 2 || Nome.Length > 50)
        {
            erros.Add("O nome deve ter entre 2 e 50 caracteres");
        }

        if (Classificacao == null)
        {
            erros.Add("A Classificação deve ser selecionada");
        }

        return erros;
    }


}
