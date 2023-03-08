using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    public class NumeroParException : Exception
    {
        public NumeroParException()
            : base("Ops! no se permiten numeros impares") { }
    }
}
