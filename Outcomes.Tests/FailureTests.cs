using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ether.Outcomes.Tests
{
    [TestClass]
    public class FailureTests
    {
        [TestMethod]
        public void Failure_Messages_Not_Null_By_Default()
        {
            IOutcome outcome = Outcomes.Failure();

            Assert.IsFalse(outcome.Success);
            Assert.IsNotNull(outcome.Messages);
            Assert.IsTrue(outcome.ToString() == string.Empty);

            //This should also work.
            IOutcome<object> o = (IOutcome<object>) outcome;
            Assert.IsNull(o.Value);

        }

        [TestMethod]
        public void Failure_OfT_Messages_Not_Null_By_Default()
        {
            IOutcome<int> outcome = Outcomes.Failure<int>();

            Assert.IsFalse(outcome.Success);
            Assert.IsNotNull(outcome.Messages);
            Assert.IsTrue(outcome.Value == 0);
            Assert.IsTrue(outcome.ToString() == string.Empty);       
        }

        [TestMethod]
        public void Failure_Basic_Chaining_Works()
        {
            var messages = new List<string> { "test2", "test3" };

            var outcome = Outcomes.Failure<int>().WithMessage("test1")
                                                 .WithMessage(messages);

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Value == 0);
            Assert.IsTrue(outcome.Messages.Count == 3);
            Assert.IsTrue(outcome.ToString() == "test1test2test3");
            Assert.IsTrue(outcome.ToString("<br>") == "test1<br>test2<br>test3<br>");
        }


        [TestMethod]
        public void Failure_Chaining_With_Syntactic_Sugar_Works()
        {
            var messages = new List<string> { "test2", "test3" };

            var outcome = Outcomes.Failure<int>().WithMessage("test1")
                                                 .WithMessagesFrom(messages);

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Value == 0);
            Assert.IsTrue(outcome.Messages.Count == 3);
            Assert.IsTrue(outcome.ToString() == "test1test2test3");
            Assert.IsTrue(outcome.ToString("<br>") == "test1<br>test2<br>test3<br>");
        }

        [TestMethod]
        public void Failure_FromException_Works()
        {
            var exception = new InvalidOperationException("test message");

            var outcome = Outcomes.Failure().FromException(exception, "prefix message");

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 2);
            Assert.IsTrue(outcome.ToString("<br>") == "prefix message<br>Exception: test message<br>");
        }


        [TestMethod]
        public void Failure_FromException_Chaining_Works()
        {
            var exception = new InvalidOperationException("test");

            var outcome = Outcomes.Failure().WithMessage("prefix")
                                            .FromException(exception)
                                            .WithMessage("suffix");
            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 3);
            Assert.IsTrue(outcome.ToString("<br>") == "prefix<br>Exception: test<br>suffix<br>");
        }


        [TestMethod]
        public void Failure_FromOutcome_Works()
        {
            var previousOutcome = Outcomes.Failure("test");

            var outcome = Outcomes.Failure().FromOutcome(previousOutcome, "prefix");

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 2);
            Assert.IsTrue(outcome.ToString("<br>") == "prefix<br>test<br>");
        }

        [TestMethod]
        public void Failure_FromOutcome_Chaining_Works()
        {
            var previousOutcome = Outcomes.Failure("test");

            var outcome = Outcomes.Failure().WithMessage("prefix")
                                            .FromOutcome(previousOutcome)
                                            .WithMessage("suffix");

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 3);
            Assert.IsTrue(outcome.ToString("<br>") == "prefix<br>test<br>suffix<br>");
        }

        [TestMethod]
        public void Failure_Chaining_Syntactic_Sugar_Works()
        {
            var previousOutcome = Outcomes.Failure("test");

            var outcome = Outcomes.Failure().WithMessage("prefix")
                                            .WithMessagesFrom(previousOutcome)
                                            .WithMessage("suffix");

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 3);
            Assert.IsTrue(outcome.ToString("<br>") == "prefix<br>test<br>suffix<br>");
        }
    }
}
