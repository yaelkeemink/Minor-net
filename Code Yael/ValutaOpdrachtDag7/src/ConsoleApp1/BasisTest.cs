using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    public class BasisTest
    {
        [TestMethod]
        public void TestCreateFlorijn()
        {
            var valuta = new Valuta(Muntsoort.Florijn);
            Assert.AreEqual(valuta.Type, Muntsoort.Florijn);
        }
        [TestMethod]
        public void TestBedrag()
        {
            var valuta = new Valuta(Muntsoort.Euro, 400);
            Assert.AreEqual(valuta.Bedrag, 400);
        }
    }
}
