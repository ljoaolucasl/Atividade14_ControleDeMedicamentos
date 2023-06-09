﻿using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class TelaReposicao : TelaBase
    {
        private RepositorioReposicao repositorioReposicao;

        private RepositorioMedicamento repositorioMedicamento;

        public TelaReposicao(RepositorioReposicao repositorioReposicao, RepositorioMedicamento repositorioMedicamento)
        {
            this.repositorioReposicao = repositorioReposicao;
            this.repositorioMedicamento = repositorioMedicamento;
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
                Console.WriteLine($"(1)Visualizar {tipo}");
                Console.WriteLine($"(2)Repor {tipo}s");
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

            MostrarCabecalho(138, "Medicamentos", ConsoleColor.DarkMagenta);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -30} │ {3, -30} │ ";
            Console.Write(espacamento, "ID", "Nome", "Descrição", "Fornecedor");
            Console.Write("{0, -15}", "Quantidade");
            Console.WriteLine(" │ {0, -15}", "Requisições");
            Console.WriteLine("".PadRight(140, '―'));
            Console.ResetColor();

            foreach (Medicamento medicamento in repositorioReposicao.ListaOrganizadaPorQuantidadeEmFalta())
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
                case "2": AdicionarSolicitacao(); break;
                case "S": return false; break;
                default: break;
            }
            return true;
        }

        protected override EntidadeBase ObterCadastro()
        {
            throw new NotImplementedException();
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

        private void AdicionarSolicitacao()
        {
            VisualizarRegistro();

            if (ValidaListaVazia(repositorioReposicao.ListaOrganizadaPorQuantidadeEmFalta()))
            {
                Medicamento medicamento = (Medicamento)ObterId(repositorioMedicamento, "Digite o ID do Medicamento que deseja repor: ");

                int quantidade = ValidaNumero($"Escreva quanto de {medicamento.nome} deseja solicitar: ");

                repositorioReposicao.AdicionarQuantidadeMedicamento(medicamento, quantidade);

                VisualizarRegistro();

                MensagemColor("Reposição feita com sucesso!", ConsoleColor.DarkGreen);
            }
            Console.ReadLine();
        }
    }
}
