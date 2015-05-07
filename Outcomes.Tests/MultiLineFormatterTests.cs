using System;
using System.Collections.Generic;
using Ether.Outcomes.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ether.Outcomes.Formats;

namespace Ether.Outcomes.Tests
{
    [TestClass]
    public class MultiLineformatterTests
    {
        [TestMethod]
        public void MultiLineFormatter_Delimits_Properly()
        {
            //Normal case
            Assert.IsTrue(
                MultiLineFormatter.ToMultiLine(delimiter: "<br>",
                       messages: new List<string>() { "test1", "test2", "test3" }
                       ) == "test1<br>test2<br>test3<br>");            
        }

        [TestMethod]
        public void MultiLineFormatter_Guarantees_One_Space()
        { 
            //If delimiter is null, guarantee a space between messages.
            Assert.IsTrue(
                MultiLineFormatter.ToMultiLine(delimiter: null,
                                               messages: new List<string>() { "test1", "test2", "test3" }
                                               ) == "test1 test2 test3");

            //However, if there's already a space or multiple spaces, don't interfere with that. We just
            //want to guarantee that there's at least one space.
            Assert.IsTrue(
                MultiLineFormatter.ToMultiLine(delimiter: null,
                                               messages: new List<string>() { "test1", "test2 ", " test3" }
                                               ) == "test1 test2  test3");


            Assert.IsTrue(
                MultiLineFormatter.ToMultiLine(delimiter: null,
                                   messages: new List<string>() { " test1", "test2 ", "test3" }
                                   ) == " test1 test2 test3");
        }
    }
}
