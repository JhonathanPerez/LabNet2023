using System;

namespace labNetPractica2
{
    public class NumeroParException : Exception
    {
        public NumeroParException()
            : base("Ops! no se permiten numeros impares") { }
    }
}
