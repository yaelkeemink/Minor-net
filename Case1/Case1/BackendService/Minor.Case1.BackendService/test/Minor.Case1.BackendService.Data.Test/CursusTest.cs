using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Minor.Case1.BackendService.DAL.DatabaseContexts;
using Minor.Case1.BackendService.DAL.DAL;
using Minor.Case1.BackendService.Entities;

namespace Minor.Case1.BackendService.Data.Test
{
    [TestClass]
    public class CursusTest
    {
        private DbContextOptions _options;
        private static DbContextOptions<DatabaseContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [TestInitialize]
        public void Init()
        {
            _options = CreateNewContextOptions();
        }

        [TestMethod]
        public void TestAddCursus()
        {

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Inschrijving()
                {
                    Titel = "Cursus1",
                    Code = "C1",
                    Dagen = 3,
                });
            }

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void TestFindCursus()
        {
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Inschrijving()
                {
                    Titel = "Cursus1",
                    Code = "C1",
                    Dagen = 3,
                });
            }

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                var result = repo.Find("C1");
                Assert.AreEqual("C1", result.Code);
                Assert.AreEqual("Cursus1", result.Titel);
                Assert.AreEqual("C1", result.Code);
                Assert.AreEqual(3, result.Dagen);
            }
        }

        [TestMethod]
        public void TestDeleteCursus()
        {
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                var pen = new Inschrijving()
                {
                    Titel = "Cursus1",
                    Code = "C1",
                    Dagen = 3,
                };
                repo.Insert(pen);
                repo.Delete("C1");
            }

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(0, repo.Count());
            }
        }
        [TestMethod]
        public void TestFindAllCursuses()
        {
            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                var cursus = new Inschrijving()
                {
                    Titel = "Cursus1",
                    Code = "C1",
                    Dagen = 3,
                };
                repo.Insert(cursus);
                cursus = new Inschrijving()
                {
                    Titel = "Cursus2",
                    Code = "C2",
                    Dagen = 3,
                };
                repo.Insert(cursus);
            }

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(2, repo.Count());
            }
        }
    }
}
