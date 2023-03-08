using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labNetPractica2
{
    public class LetraException : Exception
    {
        public LetraException()
            : base("Ops! no puedes ingresar letras") { }
    }
}
