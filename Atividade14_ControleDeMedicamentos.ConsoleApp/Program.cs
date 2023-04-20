using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloReposicao;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloRequisicao;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Inicializar Repositórios
            RepositorioFornecedor repositorioFornecedor = new();
            TelaFornecedor telaFornecedor = new(repositorioFornecedor);

            RepositorioFuncionario repositorioFuncionario = new();
            TelaFuncionario telaFuncionario = new(repositorioFuncionario);

            RepositorioMedicamento repositorioMedicamento = new(repositorioFornecedor);
            TelaMedicamento telaMedicamento = new(repositorioMedicamento, repositorioFornecedor, telaFornecedor);

            RepositorioPaciente repositorioPaciente = new();
            TelaPaciente telaPaciente = new(repositorioPaciente);

            RepositorioRequisicao repositorioRequisicao = new();
            TelaRequisicao telaRequisicao = new(repositorioRequisicao, repositorioPaciente, repositorioMedicamento,
                repositorioFuncionario, telaPaciente, telaMedicamento, telaFuncionario);

            RepositorioReposicao repositorioReposicao = new(repositorioMedicamento);
            TelaReposicao telaReposicao = new(repositorioReposicao, telaMedicamento);
            #endregion

            bool continuar = true;

            repositorioFornecedor.PreCadastrarFornecedores();
            repositorioMedicamento.PreCadastrarMedicamentos();
            repositorioPaciente.PreCadastrarPacientes();
            repositorioFuncionario.PreCadastrarFuncionarios();
            
            LogoInicio();

            while (continuar)
            {
                MostrarMenuPrincipal();

                switch (ObterEscolha().ToUpper())
                {
                    case "1": telaMedicamento.MostrarMenu("Medicamentos", ConsoleColor.Cyan, repositorioMedicamento); break;
                    case "2": telaPaciente.MostrarMenu("Pacientes", ConsoleColor.DarkCyan, repositorioPaciente); break;
                    case "3": telaFuncionario.MostrarMenu("Funcionários", ConsoleColor.DarkGreen, repositorioFuncionario); break;
                    case "4": telaFornecedor.MostrarMenu("Fornecedor", ConsoleColor.DarkYellow, repositorioFornecedor); break;
                    case "5": telaReposicao.MostrarMenu("Medicamento", ConsoleColor.DarkMagenta, repositorioReposicao); break;
                    case "6": telaRequisicao.MostrarMenu("Requisição", ConsoleColor.White, repositorioRequisicao); break;
                    case "S": continuar = false; break;
                    default: break;
                }
            }
        }

        private static void MostrarMenuPrincipal()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║     Posto De Saúde     ║");
            Console.WriteLine("╚════════════════════════╝");
            Console.ResetColor();
            PulaLinha();
            Console.WriteLine("Controles e Cadastros");
            PulaLinha();
            Console.WriteLine("(1)Controle de Medicamentos");
            Console.WriteLine("(2)Cadastro de Pacientes");
            Console.WriteLine("(3)Cadastro de Funcionários");
            Console.WriteLine("(4)Cadastro de Fornecedor");
            PulaLinha();
            PulaLinha();
            Console.WriteLine("Reposições e Requisições");
            PulaLinha();
            Console.WriteLine("(5)Reposição de Medicamentos");
            PulaLinha();
            Console.WriteLine("(6)Requisição Paciente");
            PulaLinha();
            PulaLinha();
            Console.WriteLine("(S)Sair");
            PulaLinha();
            Console.Write("Escolha: ");
        }

        private static void LogoInicio()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(40, 5);
            Console.WriteLine("             ╔═════════════╗");
            Console.SetCursorPosition(40, 6);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 8);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 9);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("╔════════════╝             ╚════════════╗");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("║                                       ║");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("║                                       ║");
            Console.SetCursorPosition(40, 14);
            Console.WriteLine("║            Tecle Enter . . .          ║");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("║                                       ║");
            Console.SetCursorPosition(40, 16);
            Console.WriteLine("║                                       ║");
            Console.SetCursorPosition(40, 17);
            Console.WriteLine("╚════════════╗             ╔════════════╝");
            Console.SetCursorPosition(40, 18);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 19);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 20);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 21);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 22);
            Console.WriteLine("             ║             ║");
            Console.SetCursorPosition(40, 23);
            Console.WriteLine("             ╚═════════════╝");
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
            Console.ReadLine();
        }

        private static string ObterEscolha()
        {
            string entrada = Console.ReadLine();

            return entrada;
        }

        private static void PulaLinha()
        {
            Console.WriteLine();
        }
    }
}