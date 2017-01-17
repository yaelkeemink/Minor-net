using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag19.Monumenten.Data.Entities.Entities;
using Minor.Dag19.Monumenten.MVC.Agents;
using Minor.Dag19.Monumenten.MVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.MonumentenMVC.Test
{
    [TestClass]
    public class FrontEndTest
    {
        [TestMethod]
        public void IndexTest()
        {
            using (var monumentsController = new MonumentsController(new MonumentsAgent()))
            {
                var result = monumentsController.Index();

                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
        }
        [TestMethod]
        public void ToevoegenMonumentTest()
        {
            using (var monumentsController = new MonumentsController(new MonumentsAgent()))
            {
                var redirectResult = monumentsController.Add(new Monument()
                {
                    Name = "Monument"
                });
                var result = ((monumentsController.Index() as ViewResult).Model )as IEnumerable<Monument>;
                Assert.IsInstanceOfType(redirectResult, typeof(RedirectToActionResult));
                Assert.AreEqual(result.FirstOrDefault().Name, "Monument");
            }
        }

        [TestMethod]
        public void LocationTest()
        {
            using (var monumentsController = new MonumentsController(new MonumentsAgent()))
            {
                var redirectResult = monumentsController.Add(new Monument()
                {
                    Name = "Monument",
                    Location = "Irak"
                });
                var result = ((monumentsController.Index() as ViewResult).Model) as IEnumerable<Monument>;
                Assert.IsInstanceOfType(redirectResult, typeof(RedirectToActionResult));
                Assert.AreEqual(result.FirstOrDefault().Name, "Monument");
                Assert.AreEqual(result.FirstOrDefault().Location, "Irak");
            }
        }
        
        [TestMethod]
        public void RemoveTest()
        {
            using (var monumentsController = new MonumentsController(new MonumentsAgent()))
            {
                monumentsController.Add(new Monument()
                {
                    Id = 1,
                    Name = "Monument",
                    Location = "Irak"
                });
                monumentsController.Add(new Monument()
                {
                    Id = 2,
                    Name = "Dom",
                    Location = "Frankrijk"
                });

                var redirectResult = monumentsController.Remove("Monument");
                var result = ((monumentsController.Index() as ViewResult).Model) as IEnumerable<Monument>;
                Assert.IsInstanceOfType(redirectResult, typeof(RedirectToActionResult));
                Assert.AreEqual(1, result.Count());
                Assert.AreEqual("Dom", result.FirstOrDefault().Name);
                Assert.AreEqual("Frankrijk", result.FirstOrDefault().Location);
            }
        }
    }
}
