using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class TelaFuncionario : TelaBase
    {
        private RepositorioFuncionario repositorioFuncionario;

        public TelaFuncionario(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void VisualizarRegistro()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔" + "".PadRight(80, '═') + "╗");
            Console.WriteLine("║                                  Funcionários                                  ║");
            Console.WriteLine("╚" + "".PadRight(80, '═') + "╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -20} │ {3, -18}";
            Console.WriteLine(espacamento, "ID", "Nome", "CPF", "Telefone");
            Console.WriteLine("".PadRight(82, '―'));
            Console.ResetColor();

            foreach (Funcionario funcionario in repositorioFuncionario.ObterListaRegistros())
            {
                TextoZebrado();

                Console.WriteLine(espacamento, "#" + funcionario.id, funcionario.nome, funcionario.cpf, funcionario.telefone);
            }

            Console.ResetColor();
            zebrado = true;

            PulaLinha();
        }

        public override EntidadeBase ObterCadastro()
        {
            Funcionario funcionario = new()
            {
                nome = ObterNome(),
                cpf = ObterCPF(),
                telefone = ObterTelefone()
            };
            return funcionario;
        }

        private string ObterNome()
        {
            Console.Write("Escreva o Nome: ");
            string nome = Console.ReadLine();
            return nome;
        }

        private ulong ObterCPF()
        {
            ulong cpf = ValidaNumero("Escreva o CPF: ");
            return cpf;
        }

        private ulong ObterTelefone()
        {
            ulong telefone = ValidaNumero("Escreva o Telefone: ");
            return telefone;
        }
    }
}
