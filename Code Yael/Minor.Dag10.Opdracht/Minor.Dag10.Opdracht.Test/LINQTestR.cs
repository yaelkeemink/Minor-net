using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht.Test
{
    [TestClass]
    public class LINQTestR
    {
        [TestMethod]
        public void AllNamesWithRJustSmallLettersExtensionMethod()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var result = tree.Where(name => name.Contains("r"))
                .ToList();

            Assert.AreEqual("Gert", result[0]);
            Assert.AreEqual("Jeroen", result[1]);
            Assert.AreEqual("Joery", result[2]);
            Assert.AreEqual("Lars", result[3]);
            Assert.AreEqual("Martijn", result[4]);
            Assert.AreEqual("Martin", result[5]);
            Assert.AreEqual("Robert-Jan", result[6]);
            Assert.AreEqual("Rory", result[7]);            
            Assert.AreEqual("Wouter", result[8]);
        }
        [TestMethod]
        public void AllNamesWithRJustSmallLettersComprehensionMethod()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var sorted = from name in tree
                         where name.Contains("r")
                         select name;
            var result = sorted.ToList();

            Assert.AreEqual("Gert", result[0]);
            Assert.AreEqual("Jeroen", result[1]);
            Assert.AreEqual("Joery", result[2]);
            Assert.AreEqual("Lars", result[3]);
            Assert.AreEqual("Martijn", result[4]);
            Assert.AreEqual("Martin", result[5]);
            Assert.AreEqual("Robert-Jan", result[6]);
            Assert.AreEqual("Rory", result[7]);
            Assert.AreEqual("Wouter", result[8]);
        }
        [TestMethod]
        public void AllNamesWithRComprehensionMethod()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var sorted = from name in tree
                         where name.Contains("r") || name.Contains("R")
                         select name;
            var result = sorted.ToList();

            Assert.AreEqual("Gert", result[0]);
            Assert.AreEqual("Jeroen", result[1]);
            Assert.AreEqual("Joery", result[2]);
            Assert.AreEqual("Lars", result[3]);
            Assert.AreEqual("Martijn", result[4]);
            Assert.AreEqual("Martin", result[5]);
            Assert.AreEqual("Rob", result[6]);
            Assert.AreEqual("Robert-Jan", result[7]);
            Assert.AreEqual("Rory", result[8]);
            Assert.AreEqual("Rouke", result[9]);
            Assert.AreEqual("Wouter", result[10]);
        }
        [TestMethod]
        public void AllNamesWithRExtensionMethod()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var result = tree.Where(name => name.Contains("R") || name.Contains("r"))
                .ToList();

            Assert.AreEqual("Gert", result[0]);
            Assert.AreEqual("Jeroen", result[1]);
            Assert.AreEqual("Joery", result[2]);
            Assert.AreEqual("Lars", result[3]);
            Assert.AreEqual("Martijn", result[4]);
            Assert.AreEqual("Martin", result[5]);
            Assert.AreEqual("Rob", result[6]);
            Assert.AreEqual("Robert-Jan", result[7]);
            Assert.AreEqual("Rory", result[8]);
            Assert.AreEqual("Rouke", result[9]);
            Assert.AreEqual("Wouter", result[10]);
        }
        [TestMethod]
        public void AlleVoorlettersVanNamenMetRExtensionMethod()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var result = tree.Where(name => name.Contains("R") || name.Contains("r"))
                .Select(a => a.Substring(0,1))
                .ToList();

            Assert.AreEqual("G", result[0]);
            Assert.AreEqual("J", result[1]);
            Assert.AreEqual("J", result[2]);
            Assert.AreEqual("L", result[3]);
            Assert.AreEqual("M", result[4]);
            Assert.AreEqual("M", result[5]);
            Assert.AreEqual("R", result[6]);
            Assert.AreEqual("R", result[7]);
            Assert.AreEqual("R", result[8]);
            Assert.AreEqual("R", result[9]);
            Assert.AreEqual("W", result[10]);
        }
        [TestMethod]
        public void AlleVoorlettersVanNamenMetRComprehensionMethod()
        {
            var tree = BinairytreeTestHelper.CreateTreeWithNames();
            var sorted = from name in tree
                         where name.Contains("r") || name.Contains("R")
                         select name.Substring(0, 1);
            var result = sorted.ToList();
            Assert.AreEqual("G", result[0]);
            Assert.AreEqual("J", result[1]);
            Assert.AreEqual("J", result[2]);
            Assert.AreEqual("L", result[3]);
            Assert.AreEqual("M", result[4]);
            Assert.AreEqual("M", result[5]);
            Assert.AreEqual("R", result[6]);
            Assert.AreEqual("R", result[7]);
            Assert.AreEqual("R", result[8]);
            Assert.AreEqual("R", result[9]);
            Assert.AreEqual("W", result[10]);
        }
    }
}
