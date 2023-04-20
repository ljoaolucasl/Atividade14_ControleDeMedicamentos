using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor
{
    public class RepositorioFornecedor : RepositorioMae
    {
        public void PreCadastrarFornecedores()
        {
            Fornecedor fornecedor1 = new();
            fornecedor1.nome = "Nova Farma ltda";
            fornecedor1.cnpj = 215486;
            fornecedor1.telefone = 999332456;

            Adicionar(fornecedor1);

            Fornecedor fornecedor2 = new();
            fornecedor2.nome = "American Farma ltda";
            fornecedor2.cnpj = 4322359;
            fornecedor2.telefone = 99954384;

            Adicionar(fornecedor2);

            Fornecedor fornecedor3 = new();
            fornecedor3.nome = "Advanced Farma ltda";
            fornecedor3.cnpj = 54358746;
            fornecedor3.telefone = 3265456;

            Adicionar(fornecedor3);
        }
    }
}
