using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    public class CastTest
    {
        [TestMethod]
        public void TestCastDoubleToValuta()
        {
            double bedrag = 10.45D;
            var expected = new Valuta(Muntsoort.Euro, 10.45M);
            Valuta result = bedrag;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestCastValutaToDouble()
        {            
            var valuta = new Valuta(Muntsoort.Euro, 10.45M);
            double result = valuta;
            Assert.AreEqual(10.45D, result);
        }
    }
}
