using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFuncionario
{
    public class RepositorioFuncionario : RepositorioBase
    {
        public void PreCadastrarFuncionarios()
        {
            Funcionario funcionario1 = new();
            funcionario1.nome = "Diego Da Silva";
            funcionario1.cpf = "25486";
            funcionario1.telefone = "9998456";

            Adicionar(funcionario1);

            Funcionario funcionario2 = new();
            funcionario2.nome = "Marta Pereira";
            funcionario2.cpf = "54879";
            funcionario2.telefone = "9995684";

            Adicionar(funcionario2);

            Funcionario funcionario3 = new();
            funcionario3.nome = "Pedro Antunes";
            funcionario3.cpf = "58746";
            funcionario3.telefone = "3222456";

            Adicionar(funcionario3);
        }
    }
}
