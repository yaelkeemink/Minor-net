using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Case1.BackendService.WebApi.Helpers;
using Minor.Case1.BackendService.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.BackendService.WebApi.Test
{
    [TestClass]
    public class DateHelperTest
    {
        [TestMethod]
        public void TestGetWeekBereik()
        {
            DateModel result = DateHelper.GetWeekBereik(2016, 41);
            var expectedStartDatum = new DateTime(2016, 10, 10);
            var expectedEindDatum = new DateTime(2016, 10, 16);
            Assert.AreEqual(expectedStartDatum, result.StartDatum);
            Assert.AreEqual(expectedEindDatum, result.EindDatum);
        }
    }
}
