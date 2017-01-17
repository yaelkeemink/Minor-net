using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag16.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag16.Repository.Test
{
    [TestClass]
    public class Program
    {
        [TestMethod]
        public void InsertTest()
        {
            using (var target = new ProductRepository())
            {
                var product = new Products()
                {
                    ProductName = "Product12"
                };
                target.Insert(product);
                var result = target.FindBy(a => a.ProductName == product.ProductName).FirstOrDefault();
                Assert.AreEqual(result.ProductName, "Product12");
            }
        }
        [TestMethod]
        public void Delete()
        {
            using (var target = new ProductRepository())
            {
                var toRemove = target.FindBy(a => a.ProductName == "Product12").FirstOrDefault();
                target.Delete(toRemove);
                var result = target.Find(toRemove.ProductId);
                Assert.AreEqual(result, null);
            }
        }
    }
}
