using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaMae
    {
        public RepositorioFornecedor repositorioFornecedor;

        public TelaFornecedor telaFornecedor;

        public RepositorioMedicamento repositorioMedicamento;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, TelaFornecedor telaFornecedor)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.telaFornecedor = telaFornecedor;
        }

        public override void VisualizarRegistro()
        {
            Console.Clear();

            ConsoleColor cor;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔" + "".PadRight(138, '═') + "╗");
            Console.WriteLine("║                                                               Medicamentos                                                               ║");
            Console.WriteLine("╚" + "".PadRight(138, '═') + "╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.Cyan;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -30} │ {3, -30} │ ";
            Console.Write(espacamento, "ID", "Nome", "Descrição", "Fornecedor");
            Console.Write("{0, -15}", "Quantidade");
            Console.WriteLine(" │ {0, -15}", "Requisições");
            Console.WriteLine("".PadRight(140, '―'));
            Console.ResetColor();

            foreach (Medicamento medicamento in repositorioMedicamento.ObterListaRegistros())
            {
                TextoZebrado();

                cor = VerificarDisponibilidadePorCor(medicamento);

                Console.Write(espacamento, "#" + medicamento.id, medicamento.nome, medicamento.descricao, medicamento.fornecedor.nome);
                Console.ForegroundColor = cor;
                Console.Write("{0, -15}", medicamento.quantidade == 0 ? "Em Falta" : medicamento.quantidade);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" │ {0, -15}", medicamento.saida);
            }

            Console.ResetColor();
            zebrado = true;

            PulaLinha();
        }

        public ConsoleColor VerificarDisponibilidadePorCor(Medicamento medicamento)
        {
            ConsoleColor cor;

            if (medicamento.quantidade <= 10)
                cor = ConsoleColor.DarkRed;

            else if (medicamento.quantidade <= 25)
                cor = ConsoleColor.DarkYellow;

            else
                cor = ConsoleColor.White;

            return cor;
        }

        public override EntidadeMae ObterCadastro()
        {
            Medicamento medicamento = new()
            {
                nome = ObterNome(),
                descricao = ObterDescricao(),
                fornecedor = ObterPaciente(),
                quantidade = ObterQuantidade()
            };

            medicamento = VerificaMedicamentoExistente(medicamento);

            return medicamento;
        }

        private string ObterNome()
        {
            Console.Write("Escreva o Nome: ");
            string nome = Console.ReadLine();
            return nome;
        }

        private string ObterDescricao()
        {
            Console.Write("Escreva a Descrição: ");
            string descricao = Console.ReadLine();
            return descricao;
        }

        private Fornecedor ObterPaciente()
        {
            telaFornecedor.VisualizarRegistro();
            Fornecedor fornecedor = null;

            if (ValidaListaVazia(repositorioFornecedor.ObterListaRegistros()))
            {
                fornecedor = (Fornecedor)repositorioFornecedor.SelecionarId("Digite o ID do Fornecedor: ");
            }
            return fornecedor;
        }

        private int ObterQuantidade()
        {
            int quantidade = (int)ValidaNumero("Escreva a Quantidade: ");
            return quantidade;
        }

        private Medicamento VerificaMedicamentoExistente(Medicamento novoMedicamento)
        {
            foreach (Medicamento medicamento in repositorioMedicamento.ObterListaRegistros())
            {
                if (medicamento.nome == novoMedicamento.nome)
                {
                    repositorioMedicamento.AddQuantidadeMedicamento(medicamento, novoMedicamento);
                    return null;
                }
            }
            return novoMedicamento;
        }
    }
}
