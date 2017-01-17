using Minor.Dag35.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TestTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load(new AssemblyName("ConsoleApp1"));
            foreach(var type in assembly.GetTypes())
            {
                Console.WriteLine(type.FullName);
                foreach(var method in type.GetMethods())
                {
                    Console.WriteLine(method.Name);
                    if (method.GetCustomAttributes().OfType<TestAttribute>().Any())
                    {
                        foreach(var attribute in method.GetCustomAttributes().OfType<TestAttribute>())
                        {
                            object output = attribute.Output;
                            string expectedException = attribute.ExpectedException;
                            object[] input = attribute.Input;
                            var instance = Activator.CreateInstance(type);
                            var result = method.Invoke(instance, input);
                            if (result.Equals(output))
                            {
                                Console.ForegroundColor = ConsoleColor
                                    .Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                            }
                            Console.WriteLine($"result:{result}, Expected: {output}");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }
    }
}
