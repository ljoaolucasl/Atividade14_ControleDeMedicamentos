using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloPaciente
{
    public class RepositorioPaciente : RepositorioMae
    {
        public void PreCadastrarPacientes()
        {
            Paciente paciente1 = new();
            paciente1.nome = "Rodrigo Lopes";
            paciente1.cpf = 43675;
            paciente1.telefone = 9988456;

            Adicionar(paciente1);

            Paciente paciente2 = new();
            paciente2.nome = "Marcos Dos Santos";
            paciente2.cpf = 458712;
            paciente2.telefone = 9884562;

            Adicionar(paciente2);

            Paciente paciente3 = new();
            paciente3.nome = "Laís Silvano";
            paciente3.cpf = 84562;
            paciente3.telefone = 8886423;

            Adicionar(paciente3);
        }
    }
}
