using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Case1.FrontEnd.FrontEnd.Controllers;
using Minor.Case1.FrontEnd.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.FrontEnd.MVC.Test
{
    [TestClass]
    public class CursusInstantieControllerTest
    {
        [TestMethod]
        public void CursusInstantieController_IndexReturnsViewResult()
        {
            var target = new CursusInstantieController();
            var result = target.Index(1, 2016);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void CursusInstantieController_IndexReturnsCursusInstantieDetailsViewModel()
        {
            var target = new CursusInstantieController();
            var result = target.Index(1, 2016);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var resultModel = ((ViewResult)result).Model as CursusInstantieDetailsViewModel;

            Assert.AreEqual(2016, resultModel.Jaar);
            Assert.AreEqual(1, resultModel.WeekNummer);
        }

        [TestMethod]
        public void CursusInstantieController_WeekVerderReturnedRedirect()
        {
            var target = new CursusInstantieController();
            var result = target.WeekVerder(1, 2016);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));            
        }

        [TestMethod]
        public void CursusInstantieController_WeekTerugReturnedRedirect()
        {
            var target = new CursusInstantieController();
            var result = target.WeekTerug(1, 2016);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void CursusInstantieController_InschrijvingenReturnedViewResult()
        {
            var target = new CursusInstantieController();
            var result = target.Inschrijvingen(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void CursusInstantieController_InschrijvingenReturnedGoedeDataInModel()
        {
            var target = new CursusInstantieController();
            var result = target.Inschrijvingen(1);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var resultModel = ((ViewResult)result).Model as InschrijvingenViewModel;

            Assert.AreEqual(1, resultModel.InstantieId);
        }
    }
}
