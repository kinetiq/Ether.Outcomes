using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ether.Outcomes;

namespace Ether.Outcomes.Tests
{
    [TestClass]
    public class SuccessTests
    {
        [TestMethod]
        public void BasicSuccessStateTest1()
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
        public void BasicSuccessStateTest2()
        {
            IOutcome<int> Outcome = Outcomes.Success<int>();

            Assert.IsTrue(Outcome.Success);
            Assert.IsNotNull(Outcome.Messages);
            Assert.IsTrue(Outcome.Value == 0);
            Assert.IsTrue(Outcome.ToString() == string.Empty);
        }

        [TestMethod]
        public void SuccessChainingTest()
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
        public void SuccessHelpers1()
        {
            var Outcome = Outcomes.Success<Decimal>(23123.32M);

            Assert.IsTrue(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 0);
            Assert.IsTrue(Outcome.Value == 23123.32M);
            Assert.IsTrue(Outcome.ToString() == string.Empty);
            Assert.IsTrue(Outcome.ToString("<br>") == string.Empty);
        }

        [TestMethod]
        public void SuccessHelpers2()
        {
            var Outcome = Outcomes.Success<string>("9An@nsd!d", "Encrypted value retrieved in 5s!");

            Assert.IsTrue(Outcome.Success);
            Assert.IsTrue(Outcome.Value == "9An@nsd!d");
            Assert.IsTrue(Outcome.Messages.Count == 1);
            Assert.IsTrue(Outcome.ToString() == "Encrypted value retrieved in 5s!");
        }

        [TestMethod]
        public void SuccessHelpers3()
        {
            var Outcome = Outcomes.Success(23123.32M);

            Assert.IsTrue(Outcome.Success);
            Assert.IsTrue(Outcome.Messages.Count == 0);
            Assert.IsTrue(Outcome.Value == 23123.32M);
            Assert.IsTrue(Outcome.ToString() == string.Empty);
            Assert.IsTrue(Outcome.ToString("<br>") == string.Empty);
        }

        [TestMethod]
        public void SuccessHelpers4()
        {
            var Outcome = Outcomes.Success("9An@nsd!d", "Encrypted value retrieved in 5s!");

            Assert.IsTrue(Outcome.Success);
            Assert.IsTrue(Outcome.Value == "9An@nsd!d");
            Assert.IsTrue(Outcome.Messages.Count == 1);
            Assert.IsTrue(Outcome.ToString() == "Encrypted value retrieved in 5s!");
        }
    }
}
