using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CRUD
{
    public class LivroManager
    {
        public List<Livro> livros;

        public LivroManager()
        {
            livros = new List<Livro>();
        }

        public void AdicionarLivro(Livro livro)
        {
            livro.Id = livros.Count + 1;
            livros.Add(livro);
        }

        public void AtualizarLivro(Livro livro)
        {
            Livro livroExistente = livros.Find(l => l.Id == livro.Id);
            if (livroExistente != null)
            {
                livroExistente.Titulo = livro.Titulo;
                livroExistente.Autor = livro.Autor;
                livroExistente.AnoPublicacao = livro.AnoPublicacao;
            }
        }

        public void RemoverLivro(int id)
        {
            Livro livroExistente = livros.Find(l => l.Id == id);
            if (livroExistente != null)
            {
                livros.Remove(livroExistente);
            }
        }

        public List<Livro> ObterLivros()
        {
            return livros;
        }
    }
}
