using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class TelaFornecedor : TelaBase
    {
        private RepositorioFornecedor repositorioFornecedor;

        public TelaFornecedor(RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public override void VisualizarRegistro()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("╔" + "".PadRight(80, '═') + "╗");
            Console.WriteLine("║                                   Fornecedor                                   ║");
            Console.WriteLine("╚" + "".PadRight(80, '═') + "╝");
            PulaLinha();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            string espacamento = "{0, -5} │ {1, -30} │ {2, -20} │ {3, -18}";
            Console.WriteLine(espacamento, "ID", "Nome", "CNPJ", "Telefone");
            Console.WriteLine("".PadRight(82, '―'));
            Console.ResetColor();

            foreach (Fornecedor fornecedor in repositorioFornecedor.ObterListaRegistros())
            {
                TextoZebrado();

                Console.WriteLine(espacamento, "#" + fornecedor.id, fornecedor.nome, fornecedor.cnpj, fornecedor.telefone);
            }

            Console.ResetColor();
            zebrado = true;

            PulaLinha();
        }

        public override EntidadeBase ObterCadastro()
        {
            Fornecedor fornecedor = new()
            {
                nome = ObterNome(),
                cnpj = ObterCNPJ(),
                telefone = ObterTelefone()
            };
            return fornecedor;
        }

        private string ObterNome()
        {
            Console.Write("Escreva o Nome: ");
            string nome = Console.ReadLine();
            return nome;
        }

        private ulong ObterCNPJ()
        {
            ulong cnpj = ValidaNumero("Escreva o CNPJ: ");
            return cnpj;
        }

        private ulong ObterTelefone()
        {
            ulong telefone = ValidaNumero("Escreva o Telefone: ");
            return telefone;
        }
    }
}
