using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class RepositorioReposicao : RepositorioBase
    {
        private RepositorioMedicamento repositorioMedicamento;

        public RepositorioReposicao(RepositorioMedicamento repositorioMedicamento)
        {
            this.repositorioMedicamento = repositorioMedicamento;
        }

        public void AdicionarQuantidadeMedicamento(Medicamento medicamento, int quantidade)
        {
            medicamento.quantidade += quantidade;
        }

        public ArrayList ListaOrganizadaPorQuantidadeEmFalta()
        {
            ArrayList listaOrganizada = new(repositorioMedicamento.ObterListaRegistros().ToArray());

            listaOrganizada.Sort(new CompararMedicamentosEmFalta());

            return listaOrganizada;
        }
    }
}
