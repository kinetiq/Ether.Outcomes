using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ether.Outcomes.Tests
{
    [TestClass]
    public class FailureFormatTests
    {
        [TestMethod]
        public void Failure_WithMessage_Should_Support_Formatting()
        {
            IOutcome outcome = Outcomes.Failure().WithMessage("Bob {0} a {1}", "combines", "string");

            Assert.IsTrue(!outcome.Success);
            Assert.IsTrue(outcome.ToString() == "Bob combines a string");
        }
        
        [TestMethod]
        public void Failure_FromException_Should_Support_Formatting()
        {
            var exception = new InvalidOperationException("test message");

            var outcome = Outcomes.Failure().FromException(exception, "prefix message {0}", "format");

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 2);
            Assert.IsTrue(outcome.FormatMultiLine("<br>") == "prefix message format<br>Exception: test message<br>");
        }
    
        [TestMethod]
        public void Failure_FromOutcome_Should_Support_Formatting()
        {
            var previousOutcome = Outcomes.Failure()
                                          .WithMessage("test");

            var outcome = Outcomes.Failure()
                                  .FromOutcome(previousOutcome, "prefix {0}", "format");

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 2);
            Assert.IsTrue(outcome.FormatMultiLine("<br>") == "prefix format<br>test<br>");
        }
    }
}
