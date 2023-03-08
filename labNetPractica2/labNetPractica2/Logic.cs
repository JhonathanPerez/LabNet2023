using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    public class Logic
    {
        public void DispararExecpcion()
        {
            throw new ArrayTypeMismatchException();
        }

        public void NumeroPar(int numero)
        {
            if (numero % 2 != 0)
            {
                throw new NumeroParException();
            }
        }
    }
}
