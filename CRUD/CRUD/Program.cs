using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            LivroManager livroManager = new LivroManager();

            bool executando = true;
            while (executando)
            {
                Console.WriteLine("#GERENCIAMENTO DE LIVROS#");
                Console.WriteLine("\n");
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("\n");
                Console.WriteLine("1 - Adicionar livro.");
                Console.WriteLine("2 - Atualizar livro.");
                Console.WriteLine("3 - Remover livro.");
                Console.WriteLine("4 - Listar livros.");
                Console.WriteLine("5 - Sair.");
                Console.WriteLine("\n");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarLivro(livroManager);
                        break;
                    case "2":
                        AtualizarLivro(livroManager);
                        break;
                    case "3":
                        RemoverLivro(livroManager);
                        break;
                    case "4":
                        ListarLivros(livroManager);
                        break;
                    case "5":
                        executando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

                Console.WriteLine();
                if (executando)
                {
                    Console.WriteLine("Pressione qualquer tecla para VOLTAR AO MENU ou 'S' para sair do programa...");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.S)
                    {
                        executando = false;
                    }
                    Console.Clear();
                }
            }
        }

        static void AdicionarLivro(LivroManager livroManager)
        {
            Livro livro = new Livro();

            Console.WriteLine("#ADICIONAR LIVRO#");
            Console.WriteLine("\n");

            Console.Write("Título: ");
            livro.Titulo = LerEntradaValida();

            Console.Write("Autor: ");
            livro.Autor = LerEntradaValida();

            Console.Write("Ano de Publicação: ");
            livro.AnoPublicacao = LerApenasNumero();

            livroManager.AdicionarLivro(livro);

            Console.WriteLine("Livro adicionado com sucesso!");
        }

        static string LerEntradaValida()
        {
            string input;
            bool valido = false;
            do
            {
                input = Console.ReadLine();
                valido = !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
                if (!valido)
                {
                    Console.Write("Apenas TEXTOS são permitidos neste campo. Digite novamente: ");
                }
            } while (!valido);
            return input;
        }

        static int LerApenasNumero()
        {
            int numero;
            bool valido = false;
            do
            {
                string input = Console.ReadLine();
                valido = int.TryParse(input, out numero);
                if (!valido)
                {
                    Console.Write("Apenas NÚMEROS são permitidos neste campo. Digite novamente: ");
                }
            } while (!valido);
            return numero;
        }

        static void AtualizarLivro(LivroManager livroManager)
        {
            Console.WriteLine("#ATUALIZAR LIVRO#");
            Console.WriteLine("\n");

            Console.Write("ID do livro a ser atualizado: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Livro livroExistente = livroManager.ObterLivros().Find(l => l.Id == id);
            if (livroExistente != null)
            {
                Console.Write("Novo título: ");
                livroExistente.Titulo = Console.ReadLine();

                Console.Write("Novo autor: ");
                livroExistente.Autor = Console.ReadLine();

                Console.Write("Novo ano de publicação: ");
                livroExistente.AnoPublicacao = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Livro atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RemoverLivro(LivroManager livroManager)
        {
            Console.WriteLine("#REMOVER LIVRO#");
            Console.WriteLine("\n");

            Console.Write("ID do livro a ser removido: ");
            int id = Convert.ToInt32(Console.ReadLine());

            livroManager.RemoverLivro(id);

            Console.WriteLine("Livro removido com sucesso!");
        }

        static void ListarLivros(LivroManager livroManager)
        {
            Console.WriteLine("#LISTAR LIVROS#");
            Console.WriteLine("\n");

            List<Livro> livros = livroManager.ObterLivros();
            foreach (Livro livro in livros)
            {
                Console.WriteLine($"ID: {livro.Id}, Título: {livro.Titulo}, Autor: {livro.Autor}, Ano de Publicação: {livro.AnoPublicacao}");
            }
        }
    }
}
