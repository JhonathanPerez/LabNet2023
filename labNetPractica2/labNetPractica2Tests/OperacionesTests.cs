using labNetPractica2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace labNetPractica2.Tests
{
    [TestClass()]
    public class OperacionesTests
    {
        [TestMethod()]
        public void DividirTest()
        {
            int numero1 = 10;
            int numero2 = 2;
            int resultadoEsperado = 5;
            int resultadoActual;

            Operaciones operacion = new Operaciones();
            resultadoActual = operacion.Dividir(numero1, numero2);

            Assert.AreEqual(resultadoActual, resultadoEsperado);
        }

        [TestMethod()]
        [ExpectedException(typeof(System.DivideByZeroException))]
        public void DividirTest1()
        {
            int numero1 = 10;
            int numero2 = 0;

            Operaciones operacion = new Operaciones();
            operacion.Dividir(numero1, numero2);
        }
    }
}
