using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloReposicao;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        public virtual void MostrarMenu(string tipo, ConsoleColor cor, RepositorioBase tipoRepositorio)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.ForegroundColor = cor;
                Console.WriteLine($"Controle de {tipo}");
                Console.ResetColor();
                PulaLinha();
                Console.WriteLine($"(1)Visualizar {tipo}");
                Console.WriteLine($"(2)Adicionar {tipo}");
                Console.WriteLine($"(3)Editar {tipo}");
                Console.WriteLine($"(4)Excluir {tipo}");
                PulaLinha();
                Console.WriteLine("(S)Sair");
                PulaLinha();
                Console.Write("Escolha: ");

                continuar = InicializarOpcaoEscolhida(tipoRepositorio);
            }
        }

        public virtual bool InicializarOpcaoEscolhida(RepositorioBase tipoRepositorio)
        {
            string entrada = Console.ReadLine();

            switch (entrada.ToUpper())
            {
                case "1": VisualizarRegistro(); Console.ReadLine(); break;
                case "2": AdicionarRegistro(tipoRepositorio); break;
                case "3": EditarRegistro(tipoRepositorio); break;
                case "4": ExcluirRegistro(tipoRepositorio); break;
                case "S": return false;
                default: break;
            }
            return true;
        }

        public abstract void VisualizarRegistro();

        public virtual EntidadeBase ObterCadastro() { return null; }

        public ulong ValidaNumero(string mensagem)
        {
            bool validaNumero;
            string entrada;
            ulong numero;

            do
            {
                Console.Write(mensagem);

                entrada = Console.ReadLine();

                validaNumero = ulong.TryParse(entrada, out numero);

                if (!validaNumero)
                {
                    MensagemColor("Atenção, apenas números\n", ConsoleColor.Red);
                }

            } while (!validaNumero);

            return numero;
        }

        public bool ValidaListaVazia(ArrayList lista)
        {
            if (lista.Count == 0)
            {
                MensagemColor("A Lista está vazia . . .", ConsoleColor.DarkYellow);
                return false;
            }
            else
                return true;
        }

        public void AvisoIdInexistente()
        {
            MensagemColor("Atenção, apenas ID`s existentes\n", ConsoleColor.Red);
        }

        public EntidadeBase ObterId(RepositorioBase tipoRepositorio, string mensagem)
        {
            EntidadeBase registro;

            if (ValidaListaVazia(tipoRepositorio.ObterListaRegistros()))
            {
                while (true)
                {
                    int idEscolhido = (int)ValidaNumero(mensagem);

                    registro = tipoRepositorio.SelecionarId(idEscolhido);

                    if (registro == null)
                        AvisoIdInexistente();
                    else
                        return registro;
                }
            }
            return null;
        }

        protected void MensagemColor(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.Write(mensagem);
            Console.ResetColor();
        }

        protected void TextoZebrado()
        {
            if (zebrado)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                zebrado = false;
            }
            else { Console.ResetColor(); zebrado = true; }
        }

        protected void PulaLinha()
        {
            Console.WriteLine();
        }

        protected bool zebrado = true;

        public virtual void AdicionarRegistro(RepositorioBase tipoRepositorio)
        {
            VisualizarRegistro();

            RepositorioBase repositorio = tipoRepositorio;

            EntidadeBase registro = ObterCadastro();

            repositorio.Adicionar(registro);

            VisualizarRegistro();

            MensagemColor($"\nCadastro adicionado com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public virtual void EditarRegistro(RepositorioBase tipoRepositorio)
        {
            VisualizarRegistro();

            if (ValidaListaVazia(tipoRepositorio.ObterListaRegistros()))
            {
                EntidadeBase registroAntigo = ObterId(tipoRepositorio, "Digite o ID do Item que deseja editar: ");

                EntidadeBase registroAtualizado = ObterCadastro();

                tipoRepositorio.Editar(registroAntigo, registroAtualizado);

                VisualizarRegistro();

                MensagemColor("\nItem editado com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public virtual void ExcluirRegistro(RepositorioBase tipoRepositorio)
        {
            VisualizarRegistro();

            if (ValidaListaVazia(tipoRepositorio.ObterListaRegistros()))
            {
                EntidadeBase registroEscolhido = ObterId(tipoRepositorio, "Digite o ID do Item que deseja excluir: ");

                tipoRepositorio.Excluir(registroEscolhido);

                VisualizarRegistro();

                MensagemColor("\nItem excluído com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }
    }
}
