using MicroOpdracht;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeDay6
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestNormaal()
        {
            Kaart target = new Normaal(10M);

            Assert.IsTrue(target.Saldo == 10M);
        }

        [TestMethod]
        public void TestBetaalNormaal()
        {
            Kaart target = new Normaal(10M);

            target.Betaal(10M);

            Assert.IsTrue(target.Saldo == 0M);
        }
        [TestMethod]
        public void testGeenNegatiefSaldoNormaal()
        {
            Kaart target = new Normaal(10);

            Assert.IsTrue(target.Saldo == 10);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => target.Betaal(11));
        }
        [TestMethod]
        public void TestVIP()
        {
            Kaart target = new VIP(10M);

            Assert.IsTrue(target.Saldo == 10M);
        }
        [TestMethod]
        public void TestKortingVIP()
        {
            var target = new VIP(10M, 2.5M);

            Assert.IsTrue(target.Saldo == 10M);
            Assert.IsTrue(target.Korting == 2.5M);
        }
        [TestMethod]
        public void TestNegatiefSaldoVIP()
        {
            var target = new VIP(10M, 10M);
            target.Betaal(20M);
            Assert.IsTrue(target.Saldo == -10M);
            Assert.IsTrue(target.Korting == 10M);
        }
        [TestMethod]
        public void TestGeenNegatiefKortingVIP()
        {           
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new VIP(10M, -10M));
        }
    }
}
