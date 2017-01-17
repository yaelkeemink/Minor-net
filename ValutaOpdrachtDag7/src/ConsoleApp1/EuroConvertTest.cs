using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    public class EuroConvertTest
    {
        //Test of Euro naar alles geconvert kan worden
        [TestMethod]
        public void TestConvert10EuroToGulden()
        {
            var valuta = new Valuta(Muntsoort.Euro, 10.00M);
            Assert.AreEqual(22.04M, valuta.ConvertTo(Muntsoort.Gulden));
        }
        [TestMethod]
        public void TestConvert10EuroToFlorijn()
        {
            var valuta = new Valuta(Muntsoort.Euro, 10.00M);
            Assert.AreEqual(22.04M, valuta.ConvertTo(Muntsoort.Florijn));
        }
        [TestMethod]
        public void TestConvert10EuroToDukaat()
        {
            var valuta = new Valuta(Muntsoort.Euro, 10.00M);
            Assert.AreEqual(4.32M, valuta.ConvertTo(Muntsoort.Dukaat));
        }
        [TestMethod]
        public void TestConvert10EuroToEuro()
        {
            var valuta = new Valuta(Muntsoort.Euro, 10.00M);
            Assert.AreEqual(10M, valuta.ConvertTo(Muntsoort.Euro));
        }
    }
}
