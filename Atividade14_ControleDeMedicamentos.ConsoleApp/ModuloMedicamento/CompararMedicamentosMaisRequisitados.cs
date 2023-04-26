using System.Collections;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento
{
    public class CompararMedicamentosMaisRequisitados : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Medicamento mX = (Medicamento)x;

            Medicamento mY = (Medicamento)y;

            if (mX.saida < mY.saida)
                return 1;

            else if (mX.saida > mY.saida)
                return -1;

            else
                return 0;
        }
    }
}
