using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    public class ToStringTest
    {
        [TestMethod]
        public void TestToStringEuro()
        {
            var valuta = new Valuta(Muntsoort.Euro, 400);
            Assert.AreEqual("400EUR", valuta.ToString());
        }
        [TestMethod]
        public void TestToStringDukaat()
        {
            var valuta = new Valuta(Muntsoort.Dukaat, 400);
            Assert.AreEqual("400HD", valuta.ToString());
        }
        [TestMethod]
        public void TestToStringFlorijn()
        {
            var valuta = new Valuta(Muntsoort.Florijn, 400);
            Assert.AreEqual("400fl", valuta.ToString());
        }
        [TestMethod]
        public void TestToStringGulden()
        {
            var valuta = new Valuta(Muntsoort.Gulden, 400);
            Assert.AreEqual("400fl", valuta.ToString());
        }
        [TestMethod]
        public void TestToStringMetCommaGetal()
        {
            var valuta = new Valuta(Muntsoort.Gulden, 400.3456M);
            Assert.AreEqual("400,35fl", valuta.ToString());
        }
    }
}
