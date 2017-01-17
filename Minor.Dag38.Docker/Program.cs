using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Minor.Dag38.Docker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int counter = 0 + 1;
            while(true)
            {
                Console.WriteLine("Hello" + counter);
                counter++;
                Thread.Sleep(1000);
            }            
        }
    }
}
