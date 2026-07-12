using System;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloNivelDeDificuldade;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCurso;

public class Curso : EntidadeBase<Curso>
{
    public string Nome { get; set; }
    public int CargaHoraria { get; set; }
    public Categoria Categoria { get; set; }
    public NivelDeDificuldade NivelDeDificuldade { get; set; }

    public Curso(string nome, int cargaHoraria, Categoria categoria, NivelDeDificuldade nivelDeDificuldade)
    {
        Nome = nome;
        CargaHoraria = cargaHoraria;
        Categoria = categoria;
        NivelDeDificuldade = nivelDeDificuldade;
    }
    public Curso()
    {

    }
    public override void Atualizar(Curso entidadeAtualizada)
    {
        Curso cursoAtualizado = (Curso)entidadeAtualizada;

        Nome = cursoAtualizado.Nome;
        CargaHoraria = cursoAtualizado.CargaHoraria;
        Categoria = cursoAtualizado.Categoria;
        NivelDeDificuldade = cursoAtualizado.NivelDeDificuldade;
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
            erros.Add("o nome deve ter entre 2 e 100 caracteres");
        }

        if (CargaHoraria <= 0)
        {
            erros.Add("A carga horária deve ser maior que zero");
        }

        if (Categoria == null)
        {
            erros.Add("A categoria deve ser selecionada");
        }

        if (NivelDeDificuldade == null)
        {
            erros.Add("O nivel de dificuldade deve ser selecionado");
        }

        return erros;
    }
}
