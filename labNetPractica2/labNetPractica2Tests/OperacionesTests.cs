using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            decimal resultadoActual;

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
