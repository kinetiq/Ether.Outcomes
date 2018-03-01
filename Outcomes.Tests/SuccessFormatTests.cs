using Xunit;

namespace Ether.Outcomes.Tests
{
    public class SuccessFormatTests
    {
        [Fact]
        public void Success_WithMessageFormat()
        {
            IOutcome outcome = Outcomes.Success()
                                       .WithMessageFormat("Bob {0} at {1}", "wins", "life");

            Assert.True(outcome.Success);
            Assert.True(outcome.ToString() == "Bob wins at life");
        }
    }
}
