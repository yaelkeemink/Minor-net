using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Case1.FrontEnd.FrontEnd.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.FrontEnd.MVC.Test
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void GetWeekNummerTest()
        {
            var result = DateHelper.GetWeekNummer(new DateTime(2016, 10, 12));
            Assert.AreEqual(41, result);
        }
    }
}
