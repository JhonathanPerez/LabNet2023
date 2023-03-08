using System;

namespace labNetPractica2
{
    public class Operaciones
    {
        public int Dividir(int numero1, int numero2)
        {
            try
            {
                return numero1 / numero2;
            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw;
            }
        }
    }
}
