using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Case1.BackendService.Entities;
using Minor.Case1.BackendService.WebApi.Controllers;
using Minor.Case1.BackendService.WebApi.Models;
using Minor.Case1.BackendService.WebApi.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.WebApi.Test
{
    [TestClass]
    public class CursusInstantieControllerTest
    {
        [TestMethod]
        public void CursusGetTest()
        {
            using (var repo = new CursusInstantieRepositoryMock())
            {
                var target = new CursusInstantieController(repo);
                Assert.AreEqual(0, repo.TimesCalled);
                target.Get(new DateModel()
                {
                    Jaar = 2016,
                    Week = 4
                });

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void CursusGetReturned200Test()
        {
            using (var repo = new InschrijvingRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new InschrijvingController(repo);

                dynamic result = target.Get(1);

                Assert.AreEqual(1, repo.TimesCalled);
                Assert.AreEqual(200, result.StatusCode);
            }
        }

        [TestMethod]
        public void CursusPostTest()
        {
            using (var repo = new CursusInstantieRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new CursusInstantieController(repo);

                target.Post(new List<CursusInstantie>());

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void CursusPostReturned200Test()
        {
            using (var repo = new CursusInstantieRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new CursusInstantieController(repo);

                dynamic result = target.Post(new List<CursusInstantie>());

                Assert.AreEqual(1, repo.TimesCalled);
                Assert.AreEqual(200, result.StatusCode);
            }
        }
    }
}
