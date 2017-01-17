using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag13.StreamIO.Test
{
    [TestClass]
    public class TestArchiver
    {
        [TestMethod]
        public void ReadHeader()
        {
            var target = new Archiver();
            string location = "C:\\TestMap\\Test1.txt";
            using (FileStream file = File.Create(location))
            {
                using (StreamWriter sw = new StreamWriter(file))
                {
                    sw.WriteLine("TESTES TESTES");
                }
            }
            Thread.Sleep(100);
            target.ZipFile(location);
        
        }
    }
}
