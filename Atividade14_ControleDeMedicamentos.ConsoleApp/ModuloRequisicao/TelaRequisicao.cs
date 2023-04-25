using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class TelaRequisicao : TelaBase
    {
        public RepositorioPaciente repositorioPaciente;
        public RepositorioMedicamento repositorioMedicamento;
        public RepositorioFuncionario repositorioFuncionario;

        public TelaPaciente telaPaciente;
        public TelaMedicamento telaMedicamento;
        public TelaFuncionario telaFuncionario;

        public RepositorioRequisicao repositorioRequisicao;

        public TelaRequisicao(RepositorioRequisicao repositorioRequisicao, RepositorioPaciente repositorioPaciente,
            RepositorioMedicamento repositorioMedicamento, RepositorioFuncionario repositorioFuncionario,
            TelaPaciente telaPaciente, TelaMedicamento telaMedicamento, TelaFuncionario telaFuncionario)
        {
            this.repositorioRequisicao = repositorioRequisicao;
            this.repositorioPaciente = repositorioPaciente;
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFuncionario = repositorioFuncionario;
            this.telaPaciente = telaPaciente;
            this.telaMedicamento = telaMedicamento;
            this.telaFuncionario = telaFuncionario;
        }

        public override void VisualizarRegistro()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔" + "".PadRight(120, '═') + "╗");
            Console.WriteLine("║                                                       Requisições                                                      ║");
            Console.WriteLine("╚" + "".PadRight(120, '═') + "╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.White;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -30} │ {3, -30} │ {4, -15}";
            Console.WriteLine(espacamento, "ID", "Paciente", "Medicamento", "Funcionário Responsável", "Data");
            Console.WriteLine("".PadRight(122, '―'));
            Console.ResetColor();

            foreach (Requisicao requisicao in repositorioRequisicao.ObterListaRegistros())
            {
                TextoZebrado();

                Console.WriteLine(espacamento, "#" + requisicao.id, requisicao.paciente.nome, requisicao.medicamento.nome, requisicao.funcionario.nome, requisicao.data.ToString("d"));
            }

            Console.ResetColor();
            zebrado = true;

            PulaLinha();
        }

        public override EntidadeBase ObterCadastro()
        {
            Requisicao requisicao = new()
            {
                paciente = ObterPaciente(),
                medicamento = ObterMedicamento(),
                funcionario = ObterFuncionario(),
                data = ObterData()
            };

            return requisicao;
        }

        private Paciente ObterPaciente()
        {
            telaPaciente.VisualizarRegistro();

            Paciente paciente = null;

            if (ValidaListaVazia(repositorioPaciente.ObterListaRegistros()))
            {
                paciente = (Paciente)ObterId(repositorioPaciente, "Digite o ID do Paciente: ");
            }
            return paciente;
        }

        private Medicamento ObterMedicamento()
        {
            telaMedicamento.VisualizarRegistro();

            Medicamento medicamento = null;

            if (ValidaListaVazia(repositorioMedicamento.ObterListaRegistros()))
            {
                do
                {
                    medicamento = (Medicamento)ObterId(repositorioMedicamento, "Digite o ID do Medicamento: ");

                    if (medicamento.quantidade <= 0)
                        MensagemColor("Este Medicamento está em Falta...\n", ConsoleColor.DarkRed);

                } while (medicamento.quantidade <= 0);
                medicamento.quantidade--;
                medicamento.saida++;
            }
            return medicamento;
        }

        private Funcionario ObterFuncionario()
        {
            telaFuncionario.VisualizarRegistro();

            Funcionario funcionario = null;

            if (ValidaListaVazia(repositorioFuncionario.ObterListaRegistros()))
            {
                funcionario = (Funcionario)ObterId(repositorioFuncionario, "Digite o ID do Funcionário: ");
            }
            return funcionario;
        }

        private DateTime ObterData()
        {
            DateTime data = ValidaData("Escreva a Data da Requisição: ");
            return data;
        }

        private DateTime ValidaData(string mensagem)
        {
            bool validaData;
            string entrada;
            DateTime dataAbertura;

            do
            {
                Console.Write(mensagem);

                entrada = Console.ReadLine();

                validaData = DateTime.TryParse(entrada, out dataAbertura);

                if (!validaData)
                {
                    MensagemColor("Atenção, escreva uma data válida\n", ConsoleColor.Red);
                }

            } while (!validaData);

            return dataAbertura;
        }
    }
}
