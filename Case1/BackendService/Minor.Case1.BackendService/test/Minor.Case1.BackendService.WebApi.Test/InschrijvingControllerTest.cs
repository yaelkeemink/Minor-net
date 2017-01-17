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
    public class InschrijvingControllerTest
    {       
        [TestMethod]
        public void InschrijvingPostTest()
        {
            using (var repo = new InschrijvingRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new InschrijvingController(repo);

                target.Post(new Inschrijving()
                {                    
                });

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void InschrijvingPostReturned200Test()
        {
            using (var repo = new InschrijvingRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new InschrijvingController(repo);

                dynamic result = target.Post(new Inschrijving()
                {
                });

                Assert.AreEqual(1, repo.TimesCalled);
                Assert.AreEqual(200, result.StatusCode);
            }
        }

        [TestMethod]
        public void InschrijvingGetTest()
        {
            using (var repo = new InschrijvingRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new InschrijvingController(repo);

                target.Get(1);

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void InschrijvingGetReturned200Test()
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
    }
}
