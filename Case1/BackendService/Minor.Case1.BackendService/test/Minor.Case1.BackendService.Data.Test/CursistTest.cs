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
    public class CursistTest
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
        public void TestAddCursist()
        {
            using (var repo = new CursistRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Cursist()
                {
                    Achternaam = "Keemink",
                    Voornaam = "Yael"
                });
            }

            using (var repo = new CursistRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void TestFindCursus()
        {

            using (var repo = new CursistRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Cursist()
                {
                    Achternaam = "Keemink",
                    Voornaam = "Yael"
                });
            }
            

            using (var repo = new CursistRepository(new DatabaseContext(_options)))
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual("Keemink", result.Achternaam);
                Assert.AreEqual("Yael", result.Voornaam);
            }
        }
    }
}
