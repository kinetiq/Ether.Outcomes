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
            Assert.IsTrue(outcome.ToMultiLine("<br>") == "test1<br>test2<br>test3<br>");
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
            Assert.IsTrue(outcome.ToMultiLine("<br>") == "test1<br>test2<br>test3<br>");
        }


        [TestMethod]
        public void Failure_WithKeysFrom_Works()
        {
            var outcome1 = Outcomes.Failure()
                                   .WithKey("test", 35);

            var outcome2 = Outcomes.Failure().WithKeysFrom(outcome1);
            var outcome3 = Outcomes.Failure().FromOutcome(outcome1);

            Assert.IsTrue(outcome1.Keys["test"].Equals(35));
            Assert.IsTrue(outcome2.Keys["test"].Equals(35));
            Assert.IsTrue(outcome3.Keys["test"].Equals(35));
        }


        [TestMethod]
        public void Failure_FromException_Works()
        {
            var exception = new InvalidOperationException("test message");

            var outcome = Outcomes.Failure().FromException(exception);

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 1);
            Assert.IsTrue(outcome.ToMultiLine("<br>") == "Exception: test message<br>");
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
            Assert.IsTrue(outcome.ToMultiLine("<br>") == "prefix<br>Exception: test<br>suffix<br>");
        }

        [TestMethod]
        public void Failure_FromOutcome_Chaining_Works()
        {
            var previousOutcome = Outcomes.Failure().WithMessage("test");

            var outcome = Outcomes.Failure().WithMessage("prefix")
                                            .FromOutcome(previousOutcome)
                                            .WithMessage("suffix");

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 3);
            Assert.IsTrue(outcome.ToMultiLine("<br>") == "prefix<br>test<br>suffix<br>");
        }

        [TestMethod]
        public void Failure_Chaining_Syntactic_Sugar_Works()
        {
            var previousOutcome = Outcomes.Failure().WithMessage("test");

            var outcome = Outcomes.Failure().WithStatusCode(201)
                                            .WithMessage("prefix")
                                            .WithMessagesFrom(previousOutcome)
                                            .WithMessage("suffix");
            

            Assert.IsFalse(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 3);
            Assert.IsTrue(outcome.ToMultiLine("<br>") == "prefix<br>test<br>suffix<br>");
        }


        [TestMethod]
        public void Failure_StatusCode_Is_NullByDefault()
        {
            var outcome = Outcomes.Failure();

            Assert.IsNull(outcome.StatusCode);
        }

        [TestMethod]
        public void Failure_StatusCode_WithStatusCode_Works()
        {
            var outcome = Outcomes.Failure()
                                  .WithStatusCode(200);

            Assert.IsTrue(outcome.StatusCode == 200);
        }

        [TestMethod]
        public void Failure_WithValue_Works()
        {
            var outcome = Outcomes.Failure<Decimal>()
                                  .WithValue(23123.32M);

            Assert.IsTrue(!outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 0);
            Assert.IsTrue(outcome.Value == 23123.32M);
            Assert.IsTrue(outcome.ToString() == string.Empty);
            Assert.IsTrue(outcome.ToMultiLine("<br>") == string.Empty);
        }

        [TestMethod]
        public void Failure_Keys_WithKey_Works()
        {
            var outcome = Outcomes.Failure()
                                  .WithKey("test1", "value1")
                                  .WithKey("test2", "value2");

            Assert.IsTrue(outcome.Keys["test1"].ToString() == "value1");
            Assert.IsTrue(outcome.Keys["test2"].ToString() == "value2");
        }
    }
}
