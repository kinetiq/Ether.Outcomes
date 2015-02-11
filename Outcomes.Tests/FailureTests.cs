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
            IOutcome Outcome = Outcomes.Failure();

            Assert.IsFalse(Outcome.Success);
            Assert.IsNotNull(Outcome.Messages);
            Assert.IsTrue(Outcome.ToString() == string.Empty);

            //This should also work.
            IOutcome<object> O = (IOutcome<object>) Outcome;
            Assert.IsNull(O.Value);

        }

        [TestMethod]
        public void Failure_OfT_Messages_Not_Null_By_Default()
        {
            IOutcome<int> Outcome = Outcomes.Failure<int>();

            Assert.IsFalse(Outcome.Success);
            Assert.IsNotNull(Outcome.Messages);
            Assert.IsTrue(Outcome.Value == 0);
            Assert.IsTrue(Outcome.ToString() == string.Empty);       
        }

        [TestMethod]
        public void Failure_Basic_Chaining_Works()
        {
            var Messages = new List<string> { "test2", "test3" };

            var Outcome = Outcomes.Failure<int>().WithMessage("test1")
                                                 .WithMessage(Messages);

            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Value == 0);
            Assert.IsTrue(Outcome.Messages.Count == 3);
            Assert.IsTrue(Outcome.ToString() == "test1test2test3");
            Assert.IsTrue(Outcome.ToString("<br>") == "test1<br>test2<br>test3<br>");
        }


        [TestMethod]
        public void Failure_Chaining_With_Syntactic_Sugar_Works()
        {
            var Messages = new List<string> { "test2", "test3" };

            var Outcome = Outcomes.Failure<int>().WithMessage("test1")
                                                 .WithMessagesFrom(Messages);

            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Value == 0);
            Assert.IsTrue(Outcome.Messages.Count == 3);
            Assert.IsTrue(Outcome.ToString() == "test1test2test3");
            Assert.IsTrue(Outcome.ToString("<br>") == "test1<br>test2<br>test3<br>");
        }

        [TestMethod]
        public void Failure_FromException_Works()
        {
            var Exception = new InvalidOperationException("test message");

            var Outcome = Outcomes.Failure().FromException(Exception, "prefix message");

            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 2);
            Assert.IsTrue(Outcome.ToString("<br>") == "prefix message<br>Exception: test message<br>");
        }


        [TestMethod]
        public void Failure_FromException_Chaining_Works()
        {
            var Exception = new InvalidOperationException("test");

            var Outcome = Outcomes.Failure().WithMessage("prefix")
                                            .FromException(Exception)
                                            .WithMessage("suffix");
            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 3);
            Assert.IsTrue(Outcome.ToString("<br>") == "prefix<br>Exception: test<br>suffix<br>");
        }


        [TestMethod]
        public void Failure_FromOutcome_Works()
        {
            var PreviousOutcome = Outcomes.Failure("test");

            var Outcome = Outcomes.Failure().FromOutcome(PreviousOutcome, "prefix");

            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 2);
            Assert.IsTrue(Outcome.ToString("<br>") == "prefix<br>test<br>");
        }

        [TestMethod]
        public void Failure_FromOutcome_Chaining_Works()
        {
            var PreviousOutcome = Outcomes.Failure("test");

            var Outcome = Outcomes.Failure().WithMessage("prefix")
                                            .FromOutcome(PreviousOutcome)
                                            .WithMessage("suffix");

            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 3);
            Assert.IsTrue(Outcome.ToString("<br>") == "prefix<br>test<br>suffix<br>");
        }

        [TestMethod]
        public void Failure_Chaining_Syntactic_Sugar_Works()
        {
            var PreviousOutcome = Outcomes.Failure("test");

            var Outcome = Outcomes.Failure().WithMessage("prefix")
                                            .WithMessagesFrom(PreviousOutcome)
                                            .WithMessage("suffix");

            Assert.IsFalse(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 3);
            Assert.IsTrue(Outcome.ToString("<br>") == "prefix<br>test<br>suffix<br>");
        }
    }
}
