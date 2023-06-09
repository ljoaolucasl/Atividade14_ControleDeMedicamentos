﻿using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFornecedor;
using System.Collections;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class RepositorioMedicamento : RepositorioBase
    {
        private RepositorioFornecedor repositorioFornecedor;

        public RepositorioMedicamento(RepositorioFornecedor repositorioFornecedor)
        {
            this.repositorioFornecedor = repositorioFornecedor;
        }

        public void PreCadastrarMedicamentos()
        {
            Medicamento medicamento1 = new();
            medicamento1.nome = "Paracetamol";
            medicamento1.descricao = "dor";
            medicamento1.fornecedor = (Fornecedor)repositorioFornecedor.ObterListaRegistros()[0];
            medicamento1.quantidade = 28;

            Adicionar(medicamento1);

            Medicamento medicamento2 = new();
            medicamento2.nome = "Doril";
            medicamento2.descricao = "dor";
            medicamento2.fornecedor = (Fornecedor)repositorioFornecedor.ObterListaRegistros()[1];
            medicamento2.quantidade = 0;

            Adicionar(medicamento2);

            Medicamento medicamento3 = new();
            medicamento3.nome = "Antibiótico";
            medicamento3.descricao = "bactéria";
            medicamento3.fornecedor = (Fornecedor)repositorioFornecedor.ObterListaRegistros()[1];
            medicamento3.quantidade = 8;

            Adicionar(medicamento3);

            Medicamento medicamento4 = new();
            medicamento4.nome = "Anti-Inflamatório";
            medicamento4.descricao = "inflamações";
            medicamento4.fornecedor = (Fornecedor)repositorioFornecedor.ObterListaRegistros()[2];
            medicamento4.quantidade = 23;

            Adicionar(medicamento4);
        }

        public void AddQuantidadeMedicamento(Medicamento medicamento, Medicamento novoMedicamento)
        {
            medicamento.quantidade += novoMedicamento.quantidade;

            if (novoMedicamento.descricao != "")
                medicamento.descricao = novoMedicamento.descricao;
        }

        public ArrayList ListaOrganizadaPorRequisicoes()
        {
            ArrayList listaOrganizada = new(ObterListaRegistros().ToArray());

            listaOrganizada.Sort(new CompararMedicamentosMaisRequisitados());

            return listaOrganizada;
        }
    }
}
