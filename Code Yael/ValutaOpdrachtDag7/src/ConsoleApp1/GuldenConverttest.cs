using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    public class GuldenConverttest
    {
        //Test of Gulden naar alles geconvert kan worden
        [TestMethod]
        public void TestConvert10GuldenToEuro()
        {
            var valuta = new Valuta(Muntsoort.Gulden, 10.00M);
            Assert.AreEqual(4.54M, valuta.ConvertTo(Muntsoort.Euro));
        }
        [TestMethod]
        public void TestConvert10GuldenToFlorijn()
        {
            var valuta = new Valuta(Muntsoort.Gulden, 10.00M);
            Assert.AreEqual(10M, valuta.ConvertTo(Muntsoort.Florijn));
        }
        [TestMethod]
        public void TestConvert10GuldenToDukaat()
        {
            var valuta = new Valuta(Muntsoort.Gulden, 10.00M);
            Assert.AreEqual(1.96M, valuta.ConvertTo(Muntsoort.Dukaat));
        }
        [TestMethod]
        public void TestConvert10GuldenToGulden()
        {
            var valuta = new Valuta(Muntsoort.Gulden, 10.00M);
            Assert.AreEqual(10M, valuta.ConvertTo(Muntsoort.Gulden));
        }
    }
}
