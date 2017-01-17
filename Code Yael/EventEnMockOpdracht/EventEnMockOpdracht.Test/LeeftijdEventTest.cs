using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventEnMockOpdracht.Test
{
    [TestClass]
    public class LeeftijdEventTest
    {
        [TestMethod]
        public void VerjaardHandledAangeroepenBijVerjaar()
        {
            var persoon = new Persoon("Pietertje", 46);
            var mock = new Mock();
            persoon.LeeftijdVeranderd += mock.VerjaardHandled;
            persoon.Verjaar();

            Assert.AreEqual(1, mock.AantalKeerGeroepen);
        }
        [TestMethod]
        public void VerjaardHandledAangeroepenBijSet()
        {
            var persoon = new Persoon("Pietertje", 46);
            var mock = new Mock();
            persoon.LeeftijdVeranderd += mock.VerjaardHandled;
            persoon.Leeftijd = 13;

            Assert.AreEqual(1, mock.AantalKeerGeroepen);
        }
        [TestMethod]
        public void JuisteData()
        {
            var persoon = new Persoon("Pietertje", 46);
            var mock = new Mock();
            persoon.LeeftijdVeranderd += mock.VerjaardHandled;
            persoon.Leeftijd = 13;
            Assert.AreEqual(mock.Arg.Naam, "Pietertje");
            Assert.AreEqual(mock.Arg.NieuweLeeftijd, 13);
            Assert.AreEqual(mock.Arg.OudeLeeftijd, 46);
        }
        [TestMethod]
        public void JuisteDataBijVerjaar()
        {
            var persoon = new Persoon("Pietertje", 46);
            var mock = new Mock();
            persoon.LeeftijdVeranderd += mock.VerjaardHandled;
            persoon.Verjaar();
            Assert.AreEqual(mock.Arg.Naam, "Pietertje");
            Assert.AreEqual(mock.Arg.NieuweLeeftijd, 47);
            Assert.AreEqual(mock.Arg.OudeLeeftijd, 46);
        }
        [TestMethod]
        public void EventMaarEenKeerAangeroepen()
        {
            var persoon = new Persoon("Pietertje", 46);
            var mock = new Mock();
            persoon.LeeftijdVeranderd += mock.VerjaardHandled;
            persoon.Verjaar();
            Assert.AreEqual(1, mock.AantalKeerGeroepen);
        }
    }
}
