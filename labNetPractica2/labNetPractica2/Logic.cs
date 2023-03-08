using System;

namespace labNetPractica2
{
    public class Logic
    {
        public void DispararExcepcion()
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
