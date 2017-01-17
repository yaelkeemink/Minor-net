using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht.Test
{
    [TestClass]
    public class AmountOfNames
    {        
        [TestMethod]
        public void AmountOfNamesExtensionMethod()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();

            var result = tree.GroupBy(name => name.Count())
                .Select(name => name.Count())
                .ToList();

            Assert.AreEqual(4, result[0]);
            Assert.AreEqual(4, result[1]);
            Assert.AreEqual(1, result[2]);
            Assert.AreEqual(6, result[3]);
            Assert.AreEqual(5, result[4]);
            Assert.AreEqual(3, result[5]);
            Assert.AreEqual(1, result[6]);
            
        }
        [TestMethod]
        public void AmountOfNamesComprehensive()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();

            var sorted = from name in tree
                         group name by name.Count()
                         into names
                         select names.Count();
            var result = sorted.ToList();

            Assert.AreEqual(4, result[0]);
            Assert.AreEqual(4, result[1]);
            Assert.AreEqual(1, result[2]);
            Assert.AreEqual(6, result[3]);
            Assert.AreEqual(5, result[4]);
            Assert.AreEqual(3, result[5]);
            Assert.AreEqual(1, result[6]);

        }
    }
}
