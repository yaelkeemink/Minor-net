using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Case1.BackendService.Entities;
using Minor.Case1.BackendService.WebApi.Controllers;
using Minor.Case1.BackendService.WebApi.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.WebApi.Test
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void CursusGetTest()
        {
            using (var repo = new CursusRepositoryMock())
            {
                var target = new CursusController(repo);
                Assert.AreEqual(0, repo.TimesCalled);
                target.Get();
               
                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        //[TestMethod]
        //public void CursusGetWithIdTest()
        //{
        //    using (var repo = new RepositoryMock())
        //    {
        //        var target = new CursusController(repo);
        //        Assert.AreEqual(0, repo.TimesCalled);
        //        var result = target.Get("ID");

        //        Assert.AreEqual(1, repo.TimesCalled);
        //    }
        //}

        [TestMethod]
        public void CursusPostTest()
        {
            using (var repo = new CursusRepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new CursusController(repo);

                target.Post(new Inschrijving());

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }           
    }
}