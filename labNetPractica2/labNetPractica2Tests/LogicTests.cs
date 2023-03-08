using Microsoft.VisualStudio.TestTools.UnitTesting;
using labNetPractica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            logic.DispararExecpcion();
        }

        [TestMethod()]
        [ExpectedException(typeof(LetraException))]
        public void DispararExecpcionPersonalizadaTest()
        {
            Logic logic = new Logic();
            logic.DispararExecpcionPersonalizada();
        }
    }
}
