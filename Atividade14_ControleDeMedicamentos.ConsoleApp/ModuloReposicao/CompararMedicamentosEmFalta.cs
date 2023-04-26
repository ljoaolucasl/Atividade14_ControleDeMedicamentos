using Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloMedicamento;
using System.Collections;

namespace Atividade14_ControleDeMedicamentos.ConsoleApp.ModuloReposicao
{
    public class CompararMedicamentosEmFalta : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Medicamento mX = (Medicamento)x;

            Medicamento mY = (Medicamento)y;

            if (mX.quantidade > mY.quantidade)
                return 1;

            else if (mX.quantidade < mY.quantidade)
                return -1;

            else
                return 0;
        }
    }
}
