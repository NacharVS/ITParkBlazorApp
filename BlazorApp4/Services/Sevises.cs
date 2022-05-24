using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4
{
    public class TransientService
    {
        public int Value { get; set; }
    }

    public class SingletonService
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Value { get; set; }

        public void Inc(ref int increment)
        {
            increment++;
            Value = increment;

        }
    }
}
