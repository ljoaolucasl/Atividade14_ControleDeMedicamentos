using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;

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

            MostrarCabecalho(80, "Fornecedor", ConsoleColor.DarkYellow);
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

        protected override EntidadeBase ObterCadastro()
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
            Fornecedor fornecedor = new();
            string nome = fornecedor.ValidaCampoVazio("Escreva o Nome: ");
            return nome;
        }

        private string ObterCNPJ()
        {
            string cnpj = ValidaCNPJ("Escreva o CNPJ: ");
            return cnpj;
        }

        private string ObterTelefone()
        {
            string telefone = ValidaTelefone("Escreva o Telefone: ");
            return telefone;
        }
    }
}
