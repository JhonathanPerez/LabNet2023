using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.Logic
{
    public class WrongIdException : Exception
    {
        public WrongIdException():base("El id ingresado no existe en la base de datos") { }
    }
}
