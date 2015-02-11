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
            IOutcome Outcome = Outcomes.Success();

            Assert.IsTrue(Outcome.Success);
            Assert.IsNotNull(Outcome.Messages);
            Assert.IsTrue(Outcome.ToString() == string.Empty);

            //This should also work.
            IOutcome<object> O = (IOutcome<object>) Outcome;
            Assert.IsNull(O.Value);
        }

        [TestMethod]
        public void Success_Messages_OfT_Not_Null_By_Default()
        {
            IOutcome<int> Outcome = Outcomes.Success<int>();

            Assert.IsTrue(Outcome.Success);
            Assert.IsNotNull(Outcome.Messages);
            Assert.IsTrue(Outcome.Value == 0);
            Assert.IsTrue(Outcome.ToString() == string.Empty);
        }

        [TestMethod]
        public void Success_Basic_Chaining_Works()
        {
            var Messages = new List<string> {"test2", "test3"};

            var Outcome = Outcomes.Success<int>().WithValue(32)
                                                 .WithMessage("test1")
                                                 .WithMessage(Messages);

            Assert.IsTrue(Outcome.Success);
            Assert.IsTrue(Outcome.Value == 32);
            Assert.IsTrue(Outcome.Messages.Count == 3);
            Assert.IsTrue(Outcome.ToString() == "test1test2test3");
            Assert.IsTrue(Outcome.ToString("<br>") == "test1<br>test2<br>test3<br>");
        }

        [TestMethod]
        public void Success_WithValue_Works()
        {
            var Outcome = Outcomes.Success<Decimal>(23123.32M);

            Assert.IsTrue(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 0);
            Assert.IsTrue(Outcome.Value == 23123.32M);
            Assert.IsTrue(Outcome.ToString() == string.Empty);
            Assert.IsTrue(Outcome.ToString("<br>") == string.Empty);
        }

        [TestMethod]
        public void Success_WithValue_And_Message_Works()
        {
            var Outcome = Outcomes.Success<string>("9An@nsd!d", "Encrypted value retrieved in 5s!");

            Assert.IsTrue(Outcome.Success);
            Assert.IsTrue(Outcome.Value == "9An@nsd!d");
            Assert.IsTrue(Outcome.Messages.Count == 1);
            Assert.IsTrue(Outcome.ToString() == "Encrypted value retrieved in 5s!");
        }

        [TestMethod]
        public void Success_WithValue_Works_Even_If_Generic_Not_Specified()
        {
            var Outcome = Outcomes.Success(23123.32M);

            Assert.IsTrue(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 0);
            Assert.IsTrue(Outcome.Value == 23123.32M);
            Assert.IsTrue(Outcome.ToString() == string.Empty);
            Assert.IsTrue(Outcome.ToString("<br>") == string.Empty);
        }
    }
}
