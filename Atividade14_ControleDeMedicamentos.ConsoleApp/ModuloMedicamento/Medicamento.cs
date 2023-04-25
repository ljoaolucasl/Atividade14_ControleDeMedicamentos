using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class Medicamento : EntidadeBase
    {
        public string nome;
        public string descricao;
        public Fornecedor fornecedor;
        public int quantidade;
        public int saida = 0;
    }
}
