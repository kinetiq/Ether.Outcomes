using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ether.Outcomes.Tests
{
    [TestClass]
    public class SuccessTests
    {
        [TestMethod]
        public void Success_Messages_Not_Null_By_Default()
        {
            IOutcome outcome = Outcomes.Success();

            Assert.IsTrue(outcome.Success);
            Assert.IsNotNull(outcome.Messages);
            Assert.IsTrue(outcome.ToString() == string.Empty);

            //This should also work.
            IOutcome<object> o = (IOutcome<object>) outcome;
            Assert.IsNull(o.Value);
        }

        [TestMethod]
        public void Success_Messages_OfT_Not_Null_By_Default()
        {
            IOutcome<int> outcome = Outcomes.Success<int>();

            Assert.IsTrue(outcome.Success);
            Assert.IsNotNull(outcome.Messages);
            Assert.IsTrue(outcome.Value == 0);
            Assert.IsTrue(outcome.ToString() == string.Empty);
        }

        [TestMethod]
        public void Success_Basic_Chaining_Works()
        {
            var messages = new List<string> {"test2", "test3"};

            var outcome = Outcomes.Success<int>().WithValue(32)
                                                 .WithMessage("test1")
                                                 .WithMessage(messages);

            Assert.IsTrue(outcome.Success);
            Assert.IsTrue(outcome.Value == 32);
            Assert.IsTrue(outcome.Messages.Count == 3);
            Assert.IsTrue(outcome.ToString() == "test1test2test3");
            Assert.IsTrue(outcome.ToString("<br>") == "test1<br>test2<br>test3<br>");
        }

        [TestMethod]
        public void Success_WithValue_Works()
        {
            var outcome = Outcomes.Success<Decimal>(23123.32M);

            Assert.IsTrue(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 0);
            Assert.IsTrue(outcome.Value == 23123.32M);
            Assert.IsTrue(outcome.ToString() == string.Empty);
            Assert.IsTrue(outcome.ToString("<br>") == string.Empty);
        }

        [TestMethod]
        public void Success_WithValue_And_Message_Works()
        {
            var outcome = Outcomes.Success<string>("9An@nsd!d", "Encrypted value retrieved in 5s!");

            Assert.IsTrue(outcome.Success);
            Assert.IsTrue(outcome.Value == "9An@nsd!d");
            Assert.IsTrue(outcome.Messages.Count == 1);
            Assert.IsTrue(outcome.ToString() == "Encrypted value retrieved in 5s!");
        }

        [TestMethod]
        public void Success_WithValue_Works_Even_If_Generic_Not_Specified()
        {
            var outcome = Outcomes.Success(23123.32M);

            Assert.IsTrue(outcome.Success);
            Assert.IsTrue(outcome.Messages.Count == 0);
            Assert.IsTrue(outcome.Value == 23123.32M);
            Assert.IsTrue(outcome.ToString() == string.Empty);
            Assert.IsTrue(outcome.ToString("<br>") == string.Empty);
        }
    }
}
