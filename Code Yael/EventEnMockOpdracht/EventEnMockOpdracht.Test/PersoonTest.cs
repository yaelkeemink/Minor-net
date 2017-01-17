using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEnMockOpdracht.Test
{
    [TestClass]
    public class PersoonTest
    {
        [TestMethod]
        public void GoodConstructorTest()
        {
            var persoon = new Persoon("Pietertje", 46);

            Assert.AreEqual("Pietertje", persoon.Naam);
            Assert.AreEqual(46, persoon.Leeftijd);
        }

        [TestMethod]
        public void PersoonVerjaardTest()
        {
            var persoon = new Persoon("Pietertje", 46);

            persoon.Verjaar();

            Assert.AreEqual(47, persoon.Leeftijd);
        }        
    }
}
