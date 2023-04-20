using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class TelaPaciente : TelaMae
    {
        private RepositorioPaciente repositorioPaciente;

        public TelaPaciente(RepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
        }

        public override void VisualizarRegistro()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("╔" + "".PadRight(80, '═') + "╗");
            Console.WriteLine("║                                    Pacientes                                   ║");
            Console.WriteLine("╚" + "".PadRight(80, '═') + "╝");
            PulaLinha();
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

        public override EntidadeMae ObterCadastro()
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
