using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace labNetPractica2.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArrayTypeMismatchException))]
        public void DispararExecpcionTest()
        {
            Logic logic = new Logic();
            logic.DispararExcepcion();
        }

        [TestMethod()]
        [ExpectedException(typeof(NumeroParException))]
        public void DispararExecpcionPersonalizadaTest()
        {
            int numero = 3;
            Logic logic = new Logic();
            logic.NumeroPar(numero);
        }
    }
}
