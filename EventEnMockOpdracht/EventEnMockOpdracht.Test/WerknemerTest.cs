using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEnMockOpdracht.Test
{
    [TestClass]
    public class WerknemerTest
    {
        [TestMethod]
        public void SalarisOmhoogBijLeeftijdOmhoog()
        {
            var werknemer = new Werknemer("Pietertje", 46, 27000.00M);

            werknemer.Verjaar();
            Assert.AreEqual(27270.00M, werknemer.Salaris);
        }
        [TestMethod]
        public void SalarisOmlaagBijLeeftijdOmlaag()
        {
            var werknemer = new Werknemer("Pietertje", 46, 27000.00M);

            werknemer.Leeftijd = 45;
            Assert.AreEqual(26730.00M, werknemer.Salaris);
        }
        [TestMethod]
        public void SalarisTweeKeerOmhooBijTweeKeerLeeftijdVeranderd()
        {
            var werknemer = new Werknemer("Pietertje", 46, 27000.00M);

            werknemer.Verjaar();
            werknemer.Verjaar();
            Assert.AreEqual(27542.70M, werknemer.Salaris);
        }
    }
}
