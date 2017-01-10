using System;
using System.Collections.Generic;
using Ether.Outcomes.Tests.Helpers;

using Ether.Outcomes.Formats;
using Xunit;

namespace Ether.Outcomes.Tests
{

    public class MultiLineformatterTests
    {
        [Fact]
        public void MultiLineFormatter_Delimits_Properly()
        {
            //Normal case
            Assert.True(
                MultiLineFormatter.ToMultiLine(delimiter: "<br>",
                       messages: new List<string>() { "test1", "test2", "test3" }
                       ) == "test1<br>test2<br>test3<br>");            
        }

        [Fact]
        public void MultiLineFormatter_Guarantees_One_Space()
        { 
            //If delimiter is null, guarantee a space between messages.
            Assert.True(
                MultiLineFormatter.ToMultiLine(delimiter: null,
                                               messages: new List<string>() { "test1", "test2", "test3" }
                                               ) == "test1 test2 test3");

            //However, if there's already a space or multiple spaces, don't interfere with that. We just
            //want to guarantee that there's at least one space.
            Assert.True(
                MultiLineFormatter.ToMultiLine(delimiter: null,
                                               messages: new List<string>() { "test1", "test2 ", " test3" }
                                               ) == "test1 test2  test3");


            Assert.True(
                MultiLineFormatter.ToMultiLine(delimiter: null,
                                   messages: new List<string>() { " test1", "test2 ", "test3" }
                                   ) == " test1 test2 test3");
        }
    }
}
