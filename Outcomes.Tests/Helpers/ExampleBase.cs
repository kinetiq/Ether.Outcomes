using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ether.Outcomes.Tests.Helpers
{   
    /// <summary>
    /// These exist solely to help test whether certain capabilities relating to
    /// inheritance are working.
    /// </summary>
    public class ExampleBase
    {
        public string SomeString { get; set; }
    }

    public class ExampleConcrete : ExampleBase
    {
        public int SomeInt { get; set; }
    }
}
