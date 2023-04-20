using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloReposicao;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado
{
    public class RepositorioMae
    {
        TelaMae telaMae = new();

        private ArrayList listaRegistros = new ArrayList();

        private int id = 1;

        public void Adicionar(EntidadeMae registro)
        {
            registro.id = id; id++;
            listaRegistros.Add(registro);
        }

        public void Editar(EntidadeMae registroAntigo, EntidadeMae registroNovo)
        {
            if (registroAntigo != null)
            {
                Type tipo = registroAntigo.GetType();

                foreach (var atributo in tipo.GetFields())
                {
                    if (atributo.Name != "id")
                        atributo.SetValue(registroAntigo, atributo.GetValue(registroNovo));
                }
            }
        }

        public void Excluir(EntidadeMae registroSelecionado)
        {
            if (registroSelecionado != null)
            {
                int idIndex = listaRegistros.IndexOf(registroSelecionado);

                listaRegistros.RemoveAt(idIndex);
            }
        }

        public ArrayList ObterListaRegistros()
        {
            return listaRegistros;
        }

        public EntidadeMae SelecionarId(string mensagem)
        {
            if (telaMae.ValidaListaVazia(listaRegistros))
            {
                while (true)
                {
                    int idEscolhido = (int)telaMae.ValidaNumero(mensagem);

                    foreach (EntidadeMae registro in listaRegistros)
                        if (registro.id == idEscolhido)
                            return registro;

                    telaMae.AvisoIdInexistente();
                }
            }
            return null;
        }
    }
}
