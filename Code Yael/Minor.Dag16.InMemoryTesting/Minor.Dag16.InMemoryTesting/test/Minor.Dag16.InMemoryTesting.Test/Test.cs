using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag16.InMemoryTesting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Minor.Dag16.InMemoryTesting.DAL;

namespace Minor.Dag16.InMemoryTesting.Test
{
    [TestClass]
    public class Test
    {
        private DbContextOptions _options;
        private static DbContextOptions<PenContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<PenContext>();
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
        public void TestAdd()
        {
            
            using (var repo = new PenRepository(_options))
            {
                repo.Insert(new Pen()
                {
                    Color = "Green",
                    Type = "Marker"
                });
            }
            

            using (var repo = new PenRepository(_options))
            {
                Assert.AreEqual(1, repo.Count());
            }
        }

        [TestMethod]
        public void TestFind()
        {
            using (var repo = new PenRepository(_options))
            {
                repo.Insert(new Pen()
                {
                    Color = "Green",
                    Type = "Marker"
                });
            }

            using (var repo = new PenRepository(_options))
            {
                var result = repo.Find(1);
                Assert.AreEqual(1, result.Id);
                Assert.AreEqual("Green", result.Color);
                Assert.AreEqual("Marker", result.Type);
            }
        }
        [TestMethod]
        public void TestDelete()
        {
            using (var repo = new PenRepository(_options))
            {
                Pen pen = new Pen()
                {
                    Color = "Green",
                    Type = "Marker"
                };
                repo.Insert(pen);
                repo.Delete(1);
            }

            using (var repo = new PenRepository(_options))
            {
                Assert.AreEqual(0, repo.Count()); 
            }
        }
        [TestMethod]
        public void TestFindAll()
        {
            using (var repo = new PenRepository(_options))
            {
                Pen pen = new Pen()
                {
                    Color = "Green",
                    Type = "Marker"
                };                
                repo.Insert(pen);
                pen = new Pen()
                {
                    Color = "Blue",
                    Type = "Non marker"
                };
                repo.Insert(pen);
            }

            using (var repo = new PenRepository(_options))
            {
                Assert.AreEqual(2, repo.Count());
            }
        }
    }
}
