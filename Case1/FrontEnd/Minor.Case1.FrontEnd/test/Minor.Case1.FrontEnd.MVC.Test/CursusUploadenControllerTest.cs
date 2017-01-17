using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Case1.FrontEnd.FrontEnd.Controllers;
using Minor.Case1.FrontEnd.FrontEnd.Helpers;
using Minor.Case1.FrontEnd.FrontEnd.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Case1.FrontEnd.MVC.Test
{
    [TestClass]
    public class CursusUploadenControllerTest
    {
        [TestMethod]
        public void TestGoedVoorbeelUpload()
        {
            var target = new CursusUploadenController();

            using (var a = File.Open(@"ParserTestFiles\goedvoorbeeld.txt", FileMode.Open))
            {
                IFormFile file = new FormFile(a, 0, a.Length, "goedvoorbeeld", "goedvoorbeeld");
                var result = target.Upload(file);

                Assert.IsInstanceOfType(result, typeof(ViewResult));
                var resultModel = ((result as ViewResult).Model) as UploadResultViewModel;
                Assert.IsInstanceOfType(resultModel, typeof(UploadResultViewModel));
            }
        }
        [TestMethod]
        public void TestFoutVoorbeeld1Upload()
        {
            var target = new CursusUploadenController();

            using (var a = File.Open(@"ParserTestFiles\Fout1.txt", FileMode.Open))
            {
                IFormFile file = new FormFile(a, 0, a.Length, "Fout1", "Fout1");
                var result = target.Upload(file);

                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }
        }
        [TestMethod]
        public void TestFoutVoorbeeld2Upload()
        {
            var target = new CursusUploadenController();

            using (var a = File.Open(@"ParserTestFiles\Fout2.txt", FileMode.Open))
            {
                IFormFile file = new FormFile(a, 0, a.Length, "Fout2", "Fout2");
                var result = target.Upload(file);

                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }
        }
        [TestMethod]
        public void TestFoutVoorbeeld3Upload()
        {
            var target = new CursusUploadenController();

            using (var a = File.Open(@"ParserTestFiles\Fout3.txt", FileMode.Open))
            {
                IFormFile file = new FormFile(a, 0, a.Length, "Fout3", "Fout3");
                var result = target.Upload(file);

                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }
        }
        [TestMethod]
        public void TestFoutVoorbeeld4Upload()
        {
            var target = new CursusUploadenController();

            using (var a = File.Open(@"ParserTestFiles\Fout4.txt", FileMode.Open))
            {
                IFormFile file = new FormFile(a, 0, a.Length, "Fout4", "Fout4");
                var result = target.Upload(file);

                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }
        }
        [TestMethod]
        public void TestFoutVoorbeeld5Upload()
        {
            var target = new CursusUploadenController();

            using (var a = File.Open(@"ParserTestFiles\Fout5.txt", FileMode.Open))
            {
                IFormFile file = new FormFile(a, 0, a.Length, "Fout5", "Fout5");
                var result = target.Upload(file);

                Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            }
        }       
    }
}
