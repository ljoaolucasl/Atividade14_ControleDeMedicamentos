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

            MostrarCabecalho(80, "Funcionário", ConsoleColor.DarkGreen);
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

        protected override EntidadeBase ObterCadastro()
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
            Funcionario funcionario = new();
            string nome = funcionario.ValidaCampoVazio("Escreva o Nome: ");
            return nome;
        }

        private string ObterCPF()
        {
            string cpf = ValidaCPF("Escreva o CPF: ");
            return cpf;
        }

        private string ObterTelefone()
        {
            string telefone = ValidaTelefone("Escreva o Telefone: ");
            return telefone;
        }
    }
}
