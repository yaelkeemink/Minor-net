using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag19.Monumenten.Data.DAL;
using Minor.Dag19.Monumenten.Data.Entities.Entities;
using Minor.Dag19.Monumenten.WebApi.Controllers;
using Minor.Dag19.Monumenten.WebApi.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag19.Monumenten.WebApi.Test
{
    [TestClass]
    public class MonumentsControllerTest
    {
        [TestMethod]
        public void MonumentGetTest()
        {
            using(var repo = new RepositoryMock())
            {
                var target = new MonumentsController(repo);

                IEnumerable<Monument> result = target.Get();

                Assert.AreEqual("Dom", result.First().Name);
                Assert.AreEqual(2, result.Count());
            }
        }

        [TestMethod]
        public void MonumentGetWithIdTest()
        {
            using (var repo = new RepositoryMock())
            {
                var target = new MonumentsController(repo);

                Monument result = target.Get(2);

                Assert.AreEqual("Eifeltoren", result.Name);
                Assert.AreEqual("Frankfurt", result.Location);
                Assert.AreEqual(2, result.Id);
            }
        }

        [TestMethod]
        public void MonumentPostTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new MonumentsController(repo);

                target.Post(new Monument());
               
                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void MonumentPutTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new MonumentsController(repo);

                target.Put(new Monument());

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }

        [TestMethod]
        public void MonumentDeletTest()
        {
            using (var repo = new RepositoryMock())
            {
                Assert.AreEqual(0, repo.TimesCalled);

                var target = new MonumentsController(repo);

                target.Delete(2);

                Assert.AreEqual(1, repo.TimesCalled);
            }
        }
    }
}
