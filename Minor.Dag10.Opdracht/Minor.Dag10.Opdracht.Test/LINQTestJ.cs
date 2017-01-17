using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht.Test
{
    [TestClass]
    public class LINQTestJ
    {
        [TestMethod]
        public void TestJWithExtensionMethod()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var result = tree.Where(name => name.StartsWith("J"))                
                .Select(name => name.Count())
                .OrderByDescending(name => name)
                .ToList();
            Assert.AreEqual(8, result[0]);
            Assert.AreEqual(6, result[1]);
            Assert.AreEqual(5, result[2]);
            Assert.AreEqual(5, result[3]);
            Assert.AreEqual(3, result[4]);
        }
        [TestMethod]
        public void TestJWithComprehensive()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var sorted = from name in tree
                         where name.StartsWith("J")
                         orderby name.Count() descending
                         select name.Count();
            var result = sorted.ToList();

            Assert.AreEqual(8, result[0]);
            Assert.AreEqual(6, result[1]);
            Assert.AreEqual(5, result[2]);
            Assert.AreEqual(5, result[3]);
            Assert.AreEqual(3, result[4]);
        }
    }
}
