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
            IOutcome Outcome = Outcomes.Failure().WithMessage("Bob {0} a {1}", "combines", "string");

            Assert.IsTrue(!Outcome.Success);
            Assert.IsTrue(Outcome.ToString() == "Bob combines a string");
        }
        
        [TestMethod]
        public void Failure_FromException_Should_Support_Formatting()
        {
            var Exception = new InvalidOperationException("test message");

            var Outcome = Outcomes.Failure().FromException(Exception, "prefix message {0}", "format");

            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 2);
            Assert.IsTrue(Outcome.ToString("<br>") == "prefix message format<br>Exception: test message<br>");
        }
    
        [TestMethod]
        public void Failure_FromOutcome_Should_Support_Formatting()
        {
            var PreviousOutcome = Outcomes.Failure("test");

            var Outcome = Outcomes.Failure().FromOutcome(PreviousOutcome, "prefix {0}", "format");

            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 2);
            Assert.IsTrue(Outcome.ToString("<br>") == "prefix format<br>test<br>");
        }
    }
}
