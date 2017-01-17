using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Case1.BackendService.DAL.DAL;
using Minor.Case1.BackendService.DAL.DatabaseContexts;
using Minor.Case1.BackendService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.Data.Test
{
    [TestClass]
    public class CursusInstantieTest
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
        public void AddCursusInstantie()
        {
            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new CursusInstantie()
                {
                    CursusId = "C1",
                    StartDatum = new DateTime(2016, 10, 15),
                    Cursus = new Cursus()
                    {
                        Code = "C1",
                        Dagen = 3,
                        Titel = "Cursus1"
                    }
                });
            }

            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, repo.Count());
                Assert.AreEqual("C1", result.CursusId);
                Assert.AreEqual(new DateTime(2016, 10, 15), result.StartDatum);
            }
        }

        [TestMethod]
        public void AddRangeCursusInstantie()
        {
            int numberOfSavedChanges = 0;
            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                numberOfSavedChanges = repo.InsertRange(new List<CursusInstantie>()
                {
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 10, 15),
                    },
                    new CursusInstantie()
                    {
                        CursusId = "C2",
                        StartDatum = new DateTime(2016, 11, 15),
                    },
                });
            }

            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                var result = repo.FindAll();
                Assert.AreEqual(2, repo.Count());
                Assert.AreEqual(2, numberOfSavedChanges);
            }
        }

        [TestMethod]
        public void AddRangeMetCheckOpAlBestaandeCombinatieCursusInstantie()
        {
            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                repo.InsertRange(new List<CursusInstantie>()
                {
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 10, 15),
                    },
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 10, 15),
                    },
                });
            }

            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                var result = repo.FindAll();
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void AddRangeMetCheckOpNietBestaandeCursusEnAutomatischToevoegenCursusInstantie()
        {
            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                repo.InsertRange(new List<CursusInstantie>()
                {
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 10, 15),
                        Cursus = new Cursus()
                        {
                            Code = "C1",
                            Dagen = 2,
                            Titel = "Cursus 1"
                        },
                    },
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 11, 15),
                        Cursus = new Cursus()
                        {
                            Code = "C1",
                            Dagen = 2,
                            Titel = "Cursus 1"
                        },
                    },
                });
            }

            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                var result = repo.FindAll();
                Assert.AreEqual(2, repo.Count());
            }

            using (var repo = new CursusRepository(new DatabaseContext(_options)))
            {
                var result = repo.Find("C1");
                Assert.AreEqual(1, repo.Count());

                Assert.AreEqual(2, result.Dagen);
                Assert.AreEqual("Cursus 1", result.Titel);
                Assert.AreEqual("C1", result.Code);
            }
        }

        [TestMethod]
        public void TestFindCursusInstantie()
        {
            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new CursusInstantie()
                {
                    CursusId = "C1",
                    StartDatum = new DateTime(2016, 10, 15),
                });
                repo.Insert(new CursusInstantie()
                {
                    CursusId = "C2",
                    StartDatum = new DateTime(2016, 10, 15),
                });
            }

            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual("C1", result.CursusId);
                Assert.AreEqual(new DateTime(2016, 10, 15), result.StartDatum);
            }
        }

        [TestMethod]
        public void TestFindAllCursusInstantie()
        {
            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                repo.Insert(new CursusInstantie()
                {
                    CursusId = "C1",
                    StartDatum = new DateTime(2016, 10, 15),
                });
                repo.Insert(new CursusInstantie()
                {
                    CursusId = "C2",
                    StartDatum = new DateTime(2016, 10, 15),
                });
            }

            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                Assert.AreEqual(2, repo.Count());
            }
        }

        [TestMethod]
        public void TestFindByDatumRangeCursusInstantie()
        {
            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                repo.InsertRange(new List<CursusInstantie>()
                {
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 10, 15),
                        Cursus = new Cursus()
                        {
                            Code = "C1",
                            Dagen = 2,
                            Titel = "Cursus 1"
                        },
                    },
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 11, 15),
                        Cursus = new Cursus()
                        {
                            Code = "C1",
                            Dagen = 2,
                            Titel = "Cursus 1"
                        },
                    },
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 10, 12),
                        Cursus = new Cursus()
                        {
                            Code = "C1",
                            Dagen = 2,
                            Titel = "Cursus 1"
                        },
                    },
                });
            }

            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                var startDate = new DateTime(2016, 10, 11);
                var endDate = new DateTime(2016, 10, 17);
                var result = repo.FindBy(instantie => instantie.StartDatum >= startDate && instantie.StartDatum <= endDate);

                Assert.AreEqual(2, result.Count());
                Assert.AreEqual(10, result.FirstOrDefault().StartDatum.Month);
                Assert.IsTrue(result.FirstOrDefault().StartDatum.Day >= 11 && result.FirstOrDefault().StartDatum.Day <= 17);
            }
        }

        [TestMethod]
        public void TestFindByCursusInstantieMetCursus()
        {
            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                repo.InsertRange(new List<CursusInstantie>()
                {
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 10, 15),
                        Cursus = new Cursus()
                        {
                            Code = "C1",
                            Dagen = 2,
                            Titel = "Cursus 1"
                        },
                    },
                    new CursusInstantie()
                    {
                        CursusId = "C1",
                        StartDatum = new DateTime(2016, 11, 15),
                        Cursus = new Cursus()
                        {
                            Code = "C1",
                            Dagen = 2,
                            Titel = "Cursus 1"
                        },
                    },
                });
            }

            using (var repo = new CursusInstantieRepository(new DatabaseContext(_options)))
            {
                var startDate = new DateTime(2016, 10, 11);
                var endDate = new DateTime(2016, 10, 17);
                var result = repo.FindBy(instantie => instantie.StartDatum >= startDate && instantie.StartDatum <= endDate)
                    .FirstOrDefault();

                Assert.AreEqual("C1", result.CursusId);
                Assert.AreEqual("C1", result.Cursus.Code);
                Assert.AreEqual(2, result.Cursus.Dagen);
                Assert.AreEqual("Cursus 1", result.Cursus.Titel);
                Assert.AreEqual(new DateTime(2016, 10, 15), result.StartDatum);
            }
        }
    }
}
