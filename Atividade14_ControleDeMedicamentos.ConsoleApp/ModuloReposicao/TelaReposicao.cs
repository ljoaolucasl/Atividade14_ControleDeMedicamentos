using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class TelaReposicao : TelaMae
    {
        public RepositorioReposicao repositorioReposicao;

        public TelaMedicamento telaMedicamento;

        public TelaReposicao(RepositorioReposicao repositorioReposicao, TelaMedicamento telaMedicamento)
        {
            this.repositorioReposicao = repositorioReposicao;
            this.telaMedicamento = telaMedicamento;
        }

        public override void VisualizarRegistro()
        {
            repositorioReposicao.OrganizaMedicamentosEmFalta();

            ConsoleColor cor;

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("╔" + "".PadRight(138, '═') + "╗");
            Console.WriteLine("║                                                           Medicamentos Em Falta                                                          ║");
            Console.WriteLine("╚" + "".PadRight(138, '═') + "╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -30} │ {3, -30} │ ";
            Console.Write(espacamento, "ID", "Nome", "Descrição", "Fornecedor");
            Console.Write("{0, -15}", "Quantidade");
            Console.WriteLine(" │ {0, -15}", "Requisições");
            Console.WriteLine("".PadRight(140, '―'));
            Console.ResetColor();

            foreach (Reposicao reposicao in repositorioReposicao.ObterListaRegistros())
            {
                TextoZebrado();

                cor = telaMedicamento.VerificarDisponibilidadePorCor(reposicao.medicamento);

                Console.Write(espacamento, "#" + reposicao.id, reposicao.medicamento.nome, reposicao.medicamento.descricao, reposicao.medicamento.fornecedor.nome);
                Console.ForegroundColor = cor;
                Console.Write("{0, -15}", reposicao.medicamento.quantidade == 0 ? "Em Falta" : reposicao.medicamento.quantidade);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" │ {0, -15}", reposicao.medicamento.saida);
            }

            Console.ResetColor();
            zebrado = true;
            repositorioReposicao.RemoveMedicamentosRepostos();

            PulaLinha();
        }

        public override bool InicializarOpcaoEscolhida(RepositorioMae tipoRepositorio)
        {
            string entrada = Console.ReadLine();

            switch (entrada.ToUpper())
            {
                case "1": VisualizarRegistro(); Console.ReadLine(); break;
                case "2": AdicionarSolicitacao(); break;
                case "S": return false; break;
                default: break;
            }
            return true;
        }

        private void AdicionarSolicitacao()
        {
            VisualizarRegistro();

            if (ValidaListaVazia(repositorioReposicao.ObterListaRegistros()))
            {
                Reposicao reposicao = (Reposicao)repositorioReposicao.SelecionarId("Digite o ID do Medicamento que deseja repor: ");

                int quantidade = (int)ValidaNumero($"Escreva quanto de {reposicao.medicamento.nome} deseja solicitar: ");

                repositorioReposicao.AdicionarQuantidadeMedicamento(reposicao, quantidade);

                VisualizarRegistro();

                MensagemColor("Reposição feita com sucesso!", ConsoleColor.DarkGreen);
            }
            Console.ReadLine();
        }
    }
}
