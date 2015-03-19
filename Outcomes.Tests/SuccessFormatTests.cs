using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ether.Outcomes.Tests
{
    [TestClass]
    public class SuccessFormatTests
    {
        [TestMethod]
        public void Success_WithMessage_Supports_Format()
        {
            IOutcome outcome = Outcomes.Success().WithMessage("Bob {0} at {1}", "wins", "life");

            Assert.IsTrue(outcome.Success);
            Assert.IsTrue(outcome.ToString() == "Bob wins at life");
        }
    }
}
