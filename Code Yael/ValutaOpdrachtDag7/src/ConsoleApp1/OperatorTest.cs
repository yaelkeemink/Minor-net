using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [TestClass]
    public class OperatorTest
    {
        [TestMethod]
        public void TestPlusOperatorValuta()
        {
            var valuta = new Valuta(Muntsoort.Euro, 400);
            var toAdd = new Valuta(Muntsoort.Euro, 400);
            Valuta result = valuta + toAdd;
            Assert.AreEqual(result.Bedrag, 800);
            Assert.AreEqual(result.Type, Muntsoort.Euro);
        }
        [TestMethod]
        public void TestPlusOperatorValutaEnMuntsoorConverterNaarLinks()
        {
            var valuta = new Valuta(Muntsoort.Euro, 400);
            var toAdd = new Valuta(Muntsoort.Florijn, 400);
            Valuta result = valuta + toAdd;
            Assert.AreEqual(581.51M, result.Bedrag);
            Assert.AreEqual(Muntsoort.Euro, result.Type);
        }
        [TestMethod]
        public void TestKeerOperatorValuta()
        {
            var valuta = new Valuta(Muntsoort.Euro, 400);
            Valuta result = valuta * 2.5D;
            Assert.AreEqual(1000M, result.Bedrag);
            Assert.AreEqual(Muntsoort.Euro, result.Type);
        }
        [TestMethod]
        public void TestIsGelijkAanOperator()
        {
            var valuta1 = new Valuta(Muntsoort.Euro, 400);
            var valuta2 = new Valuta(Muntsoort.Euro, 400);

            Assert.IsTrue(valuta1 == valuta2);
        }
        [TestMethod]
        public void TestIsGelijkAanNietGelijkOperator()
        {
            var valuta1 = new Valuta(Muntsoort.Euro, 400);
            var valuta2 = new Valuta(Muntsoort.Euro, 300);
            bool result = valuta1 == valuta2 ? false : true;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestPlusPlusOperator()
        {
            var valuta = new Valuta(Muntsoort.Euro, 1.00M);
            valuta++;
            Assert.AreEqual(2.00M, valuta.Bedrag);
        }
        [TestMethod]
        public void TestPlusPlusDifficultOperator()
        {
            var valuta = new Valuta(Muntsoort.Euro, 1.00M);
            Valuta result = valuta++;
            Assert.AreEqual(2.00M, valuta.Bedrag);
            Assert.AreEqual(1.00M, result.Bedrag);
        }
        [TestMethod]
        public void TestPlusPlusAlsEerstDifficultOperator()
        {
            var valuta = new Valuta(Muntsoort.Euro, 1.00M);
            Valuta result = ++valuta;
            Assert.AreEqual(2.00M, valuta.Bedrag);
            Assert.AreEqual(2.00M, result.Bedrag);
        }
    }
}
