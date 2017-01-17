using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag10.Opdracht.Test
{
    [TestClass]
    public class BinairyTreeTest
    {
        [TestMethod]
        public void LegeBoomAanmakenEnAddgetal()
        {
            var target = new Empty<int>();

            var result = target.Add(7);

            Assert.AreEqual(1, result.Count);
        }
        [TestMethod]
        public void LegeBoomAanmakenEnTweegetallenToevoegen()
        {
            var target = new Empty<int>();

            var result = target.Add(7);
            result.Add(4);

            Assert.AreEqual(2, result.Count);
        }
        [TestMethod]
        public void ContainsTest()
        {
            var target = new Empty<int>();

            var result = target.Add(7);
            result.Add(4);

            Assert.IsTrue(result.Contains(4));
            Assert.AreEqual(2, result.Count);
        }        
        [TestMethod]
        public void Get0Test()
        {
            var target = new Empty<int>();

            var result = target.Add(7);
            result.Add(4);
            result.Add(3);
            result.Add(8);
            result.Add(2);

            Assert.AreEqual(2, result[0]);
        }
        [TestMethod]
        public void TestForEach()
        {
            var target = new Empty<int>();

            var boom = target.Add(7);
            boom.Add(4);
            boom.Add(3);
            boom.Add(8);
            boom.Add(2);
            var result = new List<int>();
            var expected = new List<int>()
            {
                2,
                3,
                4,
                7,
                8
            };
            foreach(var item in boom)
            {
                result.Add(item);
            }
            Assert.AreEqual(expected[0], result[0]);
            Assert.AreEqual(expected[1], result[1]);
            Assert.AreEqual(expected[2], result[2]);
            Assert.AreEqual(expected[3], result[3]);
            Assert.AreEqual(expected[4], result[4]);
        }
        [TestMethod]
        public void Get1Test()
        {
            var target = new Empty<int>();

            var result = target.Add(7);
            result.Add(4);
            result.Add(3);
            result.Add(8);
            result.Add(2);
            result.Add(1);

            Assert.AreEqual(2, result[1]);
        }
        [TestMethod]
        public void Get4Test()
        {
            var target = new Empty<int>();

            var boom = target.Add(7);
            boom.Add(4);
            boom.Add(3);
            boom.Add(8);
            boom.Add(2);
            boom.Add(1);

            Assert.AreEqual(1, boom[0]);
            Assert.AreEqual(2, boom[1]);
            Assert.AreEqual(3, boom[2]);
            Assert.AreEqual(4, boom[3]);
            Assert.AreEqual(7, boom[4]);
            Assert.AreEqual(8, boom[5]);
        }
        [TestMethod]
        public void AddRangeTest()
        {
            var boom = new Branch<int>(4);
            boom.AddRange(new List<int>()
            {
                3,
                5,
                1,
            });
            Assert.AreEqual(1, boom[0]);
            Assert.AreEqual(3, boom[1]);
            Assert.AreEqual(4, boom[2]);
            Assert.AreEqual(5, boom[3]);
        }
        [TestMethod]
        public void GeenDubbeleTest()
        {
            var boom = new Branch<int>(10);
            boom.Add(5);
            boom.Add(5);
            Assert.AreEqual(2, boom.Count);
            Assert.AreEqual(5, boom[0]);
            Assert.AreEqual(10, boom[1]);
        }
        [TestMethod]
        public void GeenDubbeleInAddRangeTest()
        {
            var boom = new Branch<int>(10);
            boom.AddRange(new List<int>()
            {
                8,
                8,
                3,
                9,
            });
            Assert.AreEqual(4, boom.Count);
        }
        [TestMethod]
        public void GenericTest()
        {
            var boom = new Branch<string>("f");
            boom.AddRange(new List<string>()
            {
                "a",
                "g"
            });
            Assert.AreEqual(3, boom.Count);
            Assert.AreEqual("a", boom[0]);
            Assert.AreEqual("f", boom[1]);
            Assert.AreEqual("g", boom[2]);
        }        
    }

}
