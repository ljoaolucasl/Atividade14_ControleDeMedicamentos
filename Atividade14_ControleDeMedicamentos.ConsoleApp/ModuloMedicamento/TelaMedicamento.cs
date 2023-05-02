using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloReposicao;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class TelaMedicamento : TelaBase
    {
        private RepositorioFornecedor repositorioFornecedor;

        private TelaFornecedor telaFornecedor;

        private RepositorioMedicamento repositorioMedicamento;

        private TelaReposicao telaReposicao;

        public TelaMedicamento(RepositorioMedicamento repositorioMedicamento, RepositorioFornecedor repositorioFornecedor, TelaFornecedor telaFornecedor, TelaReposicao telaReposicao)
        {
            this.repositorioMedicamento = repositorioMedicamento;
            this.repositorioFornecedor = repositorioFornecedor;
            this.telaFornecedor = telaFornecedor;
            this.telaReposicao = telaReposicao;
        }

        public override void MostrarMenu(string tipo, ConsoleColor cor, RepositorioBase tipoRepositorio)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();

                Console.ForegroundColor = cor;
                Console.WriteLine($"Controle de {tipo}");
                Console.ResetColor();
                PulaLinha();
                Console.WriteLine($"(1)Visualizar {tipo}s");
                Console.WriteLine($"(2)Adicionar {tipo}");
                Console.WriteLine($"(3)Editar {tipo}");
                Console.WriteLine($"(4)Excluir {tipo}");
                PulaLinha();
                Console.WriteLine($"(5)Visualizar {tipo}s em falta");
                Console.WriteLine($"(6)Visualizar {tipo}s mais requisitados");
                PulaLinha();
                Console.WriteLine("(S)Sair");
                PulaLinha();
                Console.Write("Escolha: ");

                continuar = InicializarOpcaoEscolhida(tipoRepositorio);
            }
        }

        public override void VisualizarRegistro()
        {
            Console.Clear();

            ConsoleColor cor;

            MostrarCabecalho(138, "Medicamentos", ConsoleColor.Cyan);
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

        protected override bool InicializarOpcaoEscolhida(RepositorioBase tipoRepositorio)
        {
            string entrada = Console.ReadLine();

            switch (entrada.ToUpper())
            {
                case "1": VisualizarRegistro(); Console.ReadLine(); break;
                case "2": AdicionarRegistro(tipoRepositorio); break;
                case "3": EditarRegistro(tipoRepositorio); break;
                case "4": ExcluirRegistro(tipoRepositorio); break;
                case "5": telaReposicao.VisualizarRegistro(); Console.ReadLine(); break;
                case "6": VisualizarMedicamentosRequisitados(); Console.ReadLine(); break;
                case "S": return false;
                default: break;
            }
            return true;
        }

        protected override void AdicionarRegistro(RepositorioBase tipoRepositorio)
        {
            VisualizarRegistro();

            RepositorioBase repositorio = tipoRepositorio;

            EntidadeBase registro = ObterCadastro();

            if (VerificaSeMedicamentoIncrementado(registro))
            {
                VisualizarRegistro();
                MensagemColor($"\nQuantidade do Medicamento Atualizada com sucesso!", ConsoleColor.Green);
                Console.ReadLine();
                return;
            }

            repositorio.Adicionar(registro);

            VisualizarRegistro();

            MensagemColor($"\nCadastro adicionado com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        protected override void EditarRegistro(RepositorioBase tipoRepositorio)
        {
            VisualizarRegistro();

            if (ValidaListaVazia(tipoRepositorio.ObterListaRegistros()))
            {
                EntidadeBase registroAntigo = ObterId(tipoRepositorio, "Digite o ID do Item que deseja editar: ");

                EntidadeBase registroAtualizado = ObterCadastro();

                if (tipoRepositorio is RepositorioMedicamento && VerificaSeMedicamentoIncrementado(registroAtualizado))
                {
                    VisualizarRegistro();
                    MensagemColor($"\nQuantidade do Medicamento Atualizada com sucesso!", ConsoleColor.Green);
                    Console.ReadLine();
                    return;
                }

                tipoRepositorio.Editar(registroAntigo, registroAtualizado);

                VisualizarRegistro();

                MensagemColor("\nItem editado com sucesso!", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        protected override EntidadeBase ObterCadastro()
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
            Medicamento medicamento = new();
            string nome = medicamento.ValidaCampoVazio("Escreva o Nome: ");
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
                fornecedor = (Fornecedor)ObterId(repositorioFornecedor, "Digite o ID do Fornecedor: ");
            }
            return fornecedor;
        }

        private int ObterQuantidade()
        {
            int quantidade = ValidaNumero("Escreva a Quantidade: ");
            return quantidade;
        }

        private void VisualizarMedicamentosRequisitados()
        {
            Console.Clear();

            ConsoleColor cor;

            MostrarCabecalho(138, "Medicamentos", ConsoleColor.Cyan);
            Console.ForegroundColor = ConsoleColor.Cyan;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -30} │ {3, -30} │ ";
            Console.Write(espacamento, "ID", "Nome", "Descrição", "Fornecedor");
            Console.Write("{0, -15}", "Quantidade");
            Console.WriteLine(" │ {0, -15}", "Requisições");
            Console.WriteLine("".PadRight(140, '―'));
            Console.ResetColor();

            foreach (Medicamento medicamento in repositorioMedicamento.ListaOrganizadaPorRequisicoes())
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

        private ConsoleColor VerificarDisponibilidadePorCor(Medicamento medicamento)
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

        private bool VerificaSeMedicamentoIncrementado(EntidadeBase medicamento)
        {
            if (medicamento == null)
            {
                return true;
            }
            return false;
        }
    }
}
