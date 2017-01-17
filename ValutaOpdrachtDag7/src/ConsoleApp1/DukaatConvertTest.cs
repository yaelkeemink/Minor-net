using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    public class DukaatConvertTest
    {
        //Test of Dukaat naar alles geconvert kan worden
        [TestMethod]
        public void TestConvert10DukaatToEuro()
        {
            var valuta = new Valuta(Muntsoort.Dukaat, 10.00M);
            Assert.AreEqual(23.14M, valuta.ConvertTo(Muntsoort.Euro));
        }
        [TestMethod]
        public void TestConvert10DukaatToGulden()
        {
            var valuta = new Valuta(Muntsoort.Dukaat, 10.00M);
            Assert.AreEqual(51.00M, valuta.ConvertTo(Muntsoort.Gulden));
        }
        [TestMethod]
        public void TestConvert10DukaatToFlorijn()
        {
            var valuta = new Valuta(Muntsoort.Dukaat, 10.00M);
            Assert.AreEqual(51M, valuta.ConvertTo(Muntsoort.Florijn));
        }
        [TestMethod]
        public void TestConvert10DukaatToDukaat()
        {
            var valuta = new Valuta(Muntsoort.Dukaat, 10.00M);
            Assert.AreEqual(10M, valuta.ConvertTo(Muntsoort.Dukaat));
        }
    }
}
