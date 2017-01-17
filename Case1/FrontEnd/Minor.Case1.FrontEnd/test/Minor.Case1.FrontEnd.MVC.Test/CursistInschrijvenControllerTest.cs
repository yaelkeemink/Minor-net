using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Case1.FrontEnd.FrontEnd.Agents.Models;
using Minor.Case1.FrontEnd.FrontEnd.Controllers;
using Minor.Case1.FrontEnd.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.FrontEnd.MVC.Test
{
    [TestClass]
    public class CursistInschrijvenControllerTest
    {
        [TestMethod]
        public void CursistInschrijven_IndexReturnedViewModel()
        {
            var target = new CursistInschrijvenController();
            var result = target.Index(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CursistInschrijven_IndexReturnedGoedeData()
        {
            var target = new CursistInschrijvenController();
            var result = target.Index(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var resultModel = ((ViewResult)result).Model as Inschrijving;

            Assert.AreEqual(1, resultModel.CursusInstantieId);
        }

        [TestMethod]
        public void CursistInschrijven_IngeschrevenReturnedGoedeData()
        {
            var target = new CursistInschrijvenController();
            var result = target.Ingeschreven(new Inschrijving() {CursusInstantieId = 2 });

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var resultModel = ((ViewResult)result).Model as Inschrijving;

            Assert.AreEqual(2, resultModel.CursusInstantieId);
        }
    }
}
