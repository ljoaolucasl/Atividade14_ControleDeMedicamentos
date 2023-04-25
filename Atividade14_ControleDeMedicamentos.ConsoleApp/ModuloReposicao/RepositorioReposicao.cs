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

        public void OrganizaMedicamentosEmFalta()
        {
            foreach (Medicamento medicamento in repositorioMedicamento.ObterListaRegistros())
            {
                Reposicao reposicao = new();
                bool remedioExistente = false;

                if (medicamento.quantidade <= 10)
                {
                    foreach (Reposicao item in ObterListaRegistros())
                    {
                        if (item.medicamento.nome == medicamento.nome)
                            remedioExistente = true;
                    }
                    if (!remedioExistente)
                    {
                        reposicao.medicamento = medicamento;
                        Adicionar(reposicao);
                    }
                }
            }
        }

        public void RemoveMedicamentosRepostos()
        {
            ArrayList novaLista = new();

            foreach (Reposicao item in ObterListaRegistros())
            {
                if (item.medicamento.quantidade <= 10)
                {
                    novaLista.Add(item);
                }
            }

            ObterListaRegistros().Clear();
            ObterListaRegistros().AddRange(novaLista);
        }

        public void AdicionarQuantidadeMedicamento(Reposicao reposicao, int quantidade)
        {
            reposicao.medicamento.quantidade += quantidade;
        }
    }
}
