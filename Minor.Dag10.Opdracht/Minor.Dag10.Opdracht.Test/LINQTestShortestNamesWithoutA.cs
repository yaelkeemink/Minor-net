using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht.Test
{
    [TestClass]
    public class LINQTestShortestNamesWithoutA
    {
        
        [TestMethod]
        public void ShortestNameExtensionMethodTest()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var result = tree.GroupBy(a => a.Count())
                .OrderBy(name => name.Key)
                .First()
                .Where(name => !name.Contains("a"))
                .ToList();
            Assert.AreEqual("Pim", result[0]);
            Assert.AreEqual("Rob", result[1]);
        }
        [TestMethod]
        public void ShortestNameComprehensiveMethodTest()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var sorted = from name in tree                         
                         group name by name.Count() into nameGroups
                         orderby nameGroups.Key
                         select nameGroups;

            var result = sorted.First()
                .Where(a => !a.Contains("a"))
                .ToList();

            Assert.AreEqual("Pim", result[0]);
            Assert.AreEqual("Rob", result[1]);
        }
        [TestMethod]
        public void LegeLijstjeTest()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            tree.Add("ad");
            var sorted = from name in tree
                         group name by name.Count() into nameGroups
                         orderby nameGroups.Key
                         select nameGroups;

            var result = sorted.First()
                .Where(a => !a.Contains("a"))
                .ToList();

            Assert.IsTrue(0 == result.Count);
        }
    }
}
