using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    public class FlorijnConvertTest
    {
        //Test of Florijn naar alles geconvert kan worden
        [TestMethod]
        public void TestConvert10FlorijnToEuro()
        {
            var valuta = new Valuta(Muntsoort.Florijn, 10.00M);
            Assert.AreEqual(4.54M, valuta.ConvertTo(Muntsoort.Euro));
        }
        [TestMethod]
        public void TestConvert10FlorijnToGulden()
        {
            var valuta = new Valuta(Muntsoort.Florijn, 10.00M);
            Assert.AreEqual(10M, valuta.ConvertTo(Muntsoort.Gulden));
        }
        [TestMethod]
        public void TestConvert10FlorijnToFlorijn()
        {
            var valuta = new Valuta(Muntsoort.Florijn, 10.00M);
            Assert.AreEqual(10M, valuta.ConvertTo(Muntsoort.Florijn));
        }
        [TestMethod]
        public void TestConvert10FlorijnToDukaat()
        {
            var valuta = new Valuta(Muntsoort.Florijn, 10.00M);
            Assert.AreEqual(1.96M, valuta.ConvertTo(Muntsoort.Dukaat));
        }
    }
}
