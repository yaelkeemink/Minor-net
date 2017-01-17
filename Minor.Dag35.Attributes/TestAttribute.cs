using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag35.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute
        : Attribute
    {
        private object _output;
        private string _expectedException;
        private object[] _input;

        public object[] Input { get { return _input; } }
        public string ExpectedException { get; set; }
        public object Output { get; set; }
        
        public TestAttribute(params object[] input)
        {
            _input = input;
            _output = Output;
            _expectedException = ExpectedException;
        }
    }
}
