using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : TelaBase
    {
        private RepositorioPaciente repositorioPaciente;

        public TelaPaciente(RepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public override void VisualizarRegistro()
        {
            Console.Clear();

            MostrarCabecalho(80, "Pacientes", ConsoleColor.DarkCyan);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -20} │ {3, -18}";
            Console.WriteLine(espacamento, "ID", "Nome", "CPF", "Telefone");
            Console.WriteLine("".PadRight(82, '―'));
            Console.ResetColor();

            foreach (Paciente paciente in repositorioPaciente.ObterListaRegistros())
            {
                TextoZebrado();

                Console.WriteLine(espacamento, "#" + paciente.id, paciente.nome, paciente.cpf, paciente.telefone);
            }

            Console.ResetColor();
            zebrado = true;

            PulaLinha();
        }

        protected override EntidadeBase ObterCadastro()
        {
            Paciente paciente = new()
            {
                nome = ObterNome(),
                cpf = ObterCPF(),
                telefone = ObterTelefone()
            };
            return paciente;
        }

        private string ObterNome()
        {
            Paciente paciente = new();
            string nome = paciente.ValidaCampoVazio("Escreva o Nome: ");
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
