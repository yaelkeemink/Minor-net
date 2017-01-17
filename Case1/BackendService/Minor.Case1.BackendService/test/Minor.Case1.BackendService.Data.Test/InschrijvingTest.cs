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
    public class InschrijvingTest
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
        public void TestAddInschrijving()
        {

            using (var repo = new InschrijvingenRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Inschrijving()
                {
                    CursistId = 1,
                    CursusInstantieId = 1,
                    Cursist = new Cursist()
                    {
                        Achternaam = "Yael",
                        Voornaam = "Keemink"
                    }
                });
            }

            using (var repo = new InschrijvingenRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void TestFindInschrijvingenByInstantie()
        {
            using (var repo = new InschrijvingenRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Inschrijving()
                {
                    CursistId = 1,
                    CursusInstantieId = 1,
                    Cursist = new Cursist()
                    {
                        Achternaam = "Yael",
                        Voornaam = "Keemink"
                    }
                });
                repo.Insert(new Inschrijving()
                {
                    CursistId = 2,
                    CursusInstantieId = 1,
                    Cursist = new Cursist()
                    {
                        Achternaam = "Piet",
                        Voornaam = "Keemink"
                    }
                });
                repo.Insert(new Inschrijving()
                {
                    CursistId = 1,
                    CursusInstantieId = 2,
                    Cursist = new Cursist()
                    {
                        Achternaam = "Yael",
                        Voornaam = "Keemink"
                    }
                });
            }

            using (var repo = new InschrijvingenRepository(new DatabaseContext(_options)))
            {
                var result = repo.FindBy(instantie => instantie.CursusInstantieId == 1);
                Assert.AreEqual(2, result.Count());
            }
        }

        [TestMethod]
        public void InschrijvingFindByMetIncludeCursistTest()
        {
            using (var repo = new InschrijvingenRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Inschrijving()
                {
                    CursistId = 1,
                    CursusInstantieId = 1,
                    Cursist = new Cursist()
                    {
                        Achternaam = "Yael",
                        Voornaam = "Keemink"
                    }
                });
                repo.Insert(new Inschrijving()
                {
                    CursistId = 2,
                    CursusInstantieId = 1,
                    Cursist = new Cursist()
                    {
                        Achternaam = "Piet",
                        Voornaam = "Keemink"
                    }
                });
                repo.Insert(new Inschrijving()
                {
                    CursistId = 1,
                    CursusInstantieId = 2,
                    Cursist = new Cursist()
                    {
                        Achternaam = "Yael",
                        Voornaam = "Keemink"
                    }
                });
            }

            using (var repo = new InschrijvingenRepository(new DatabaseContext(_options)))
            {
                var result = repo.FindBy(instantie => instantie.CursusInstantieId == 1);
                var firstResult = result.FirstOrDefault();

                Assert.AreEqual(2, result.Count());                
                Assert.IsNotNull(firstResult.Cursist);
                Assert.AreEqual("Yael", firstResult.Cursist.Achternaam);
                Assert.AreEqual("Keemink", firstResult.Cursist.Voornaam);
                Assert.AreEqual(firstResult.CursistId, firstResult.Cursist.Id);
            }
        }

        [TestMethod]
        public void InschrijvingFindByMetIncludeCursusInstantieTest()
        {
            using (var repo = new InschrijvingenRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new Inschrijving()
                {
                    CursistId = 1,
                    CursusInstantieId = 1,
                    Instantie = new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 10, 13),
                        Id = 1
                    }
                });
                repo.Insert(new Inschrijving()
                {
                    CursistId = 2,
                    CursusInstantieId = 1,                    
                });
                repo.Insert(new Inschrijving()
                {
                    CursistId = 1,
                    CursusInstantieId = 2,
                    Instantie = new CursusInstantie()
                    {
                        CursusId = "C2",
                        StartDatum = new DateTime(2016, 10, 13),
                        Id = 2
                    }
                });
            }

            using (var repo = new InschrijvingenRepository(new DatabaseContext(_options)))
            {
                var result = repo.FindBy(instantie => instantie.CursusInstantieId == 1);
                var firstResult = result.FirstOrDefault();

                Assert.AreEqual(2, result.Count());
                Assert.IsNotNull(firstResult.Instantie);
                Assert.AreEqual("C1", firstResult.Instantie.CursusId);
                Assert.AreEqual(new DateTime(2016,10,13), firstResult.Instantie.StartDatum);
                Assert.AreEqual(firstResult.CursusInstantieId, firstResult.Instantie.Id);
            }
        }
    }
}
