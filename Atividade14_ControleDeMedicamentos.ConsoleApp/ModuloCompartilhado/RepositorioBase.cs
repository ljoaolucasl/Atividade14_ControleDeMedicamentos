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
    public abstract class RepositorioBase
    {
        private ArrayList listaRegistros = new ArrayList();

        private int id = 1;

        public void Adicionar(EntidadeBase registro)
        {
            registro.id = id; id++;
            listaRegistros.Add(registro);
        }

        public void Editar(EntidadeBase registroAntigo, EntidadeBase registroNovo)
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

        public void Excluir(EntidadeBase registroSelecionado)
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

        public EntidadeBase SelecionarId(int idEscolhido)
        {
            foreach (EntidadeBase registro in listaRegistros)
                if (registro.id == idEscolhido)
                    return registro;

            return null;
        }
    }
}
