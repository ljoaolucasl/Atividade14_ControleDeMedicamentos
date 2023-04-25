using Atividade14_ControleDeMedicamentos.ConsoleApp.Compartilhado;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloFuncionario;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloPaciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloRequisicao
{
    public class Requisicao : EntidadeBase
    {
        public Paciente paciente;
        public Medicamento medicamento;
        public Funcionario funcionario;
        public DateTime data;
    }
}
