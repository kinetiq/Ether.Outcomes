using System;
using System.Collections.Generic;
using Ether.Outcomes.Tests.Helpers;

using Xunit;

namespace Ether.Outcomes.Tests
{
    public class SuccessTests
    {
        [Fact]
        public void Success_Messages_Not_Null_By_Default()
        {
            IOutcome outcome = Outcomes.Success();

            Assert.True(outcome.Success);
            Assert.NotNull(outcome.Messages);
            Assert.True(outcome.ToString() == string.Empty);
        }

        [Fact]
        public void Success_Messages_Prepend_With_Empty_Message_Collection()
        {
            IOutcome outcome = Outcomes.Success()
                .PrependMessage("This should not throw an error.");

            Assert.True(outcome.Success);
            Assert.True(outcome.Messages.Count == 1);
            Assert.True(outcome.Messages[0] == "This should not throw an error.");
        }

        [Fact]
        public void Success_Messages_Prepend_Works()
        {
            IOutcome outcome = Outcomes.Success()
                .WithMessage("Test!");

            var newOutcome = Outcomes.Success()
                .FromOutcome(outcome)
                .PrependMessage("This should be first since it's prepended!");

            Assert.True(newOutcome.Success);
            Assert.True(newOutcome.Messages.Count == 2);
            Assert.True(newOutcome.Messages[0] == "This should be first since it's prepended!");
            Assert.True(newOutcome.Messages[1] == "Test!");
        }

        [Fact]
        public void Success_Messages_OfT_Not_Null_By_Default()
        {
            IOutcome<int> outcome = Outcomes.Success<int>();

            Assert.True(outcome.Success);
            Assert.NotNull(outcome.Messages);
            Assert.True(outcome.Value == 0);
            Assert.True(outcome.ToString() == string.Empty);
        }

        [Fact]
        public void Success_Basic_Chaining_Works()
        {
            var messages = new List<string> {"test2", "test3"};

            var outcome = Outcomes.Success<int>()
                .WithValue(32)
                .WithMessage("test1")
                .WithMessage(messages);

            Assert.True(outcome.Success);
            Assert.True(outcome.Value == 32);

            Assert.True(outcome.Messages.Count == 3);
            Assert.True(outcome.ToString() == "test1test2test3");
            Assert.True(outcome.ToMultiLine("<br>") == "test1<br>test2<br>test3<br>");
        }

        [Fact]
        public void Success_WithKeysFrom_Works()
        {
            var outcome1 = Outcomes.Success<int>()
                                  .WithKey("test", 35);

            var outcome2 = Outcomes.Success().WithKeysFrom(outcome1);
            var outcome3 = Outcomes.Success().FromOutcome(outcome1);

            Assert.True(outcome1.Keys["test"].Equals(35));
            Assert.True(outcome2.Keys["test"].Equals(35));
            Assert.True(outcome3.Keys["test"].Equals(35));
        }

        [Fact]
        public void Success_FromOutcome_Persists_Values()
        {
            var outcome1 = Outcomes.Success<int>()
                .WithValue(10)
                .WithKey("StatusCode", 505);
            
            var outcome2 = Outcomes.Success()
                .WithValue(20)
                .WithKey("StatusCode", null);

            //In this case, some casting is going to happen.
            var outcome3 = Outcomes.Success<ExampleConcrete>()
                                   .WithValue(new ExampleConcrete() { SomeInt = 0, SomeString = "not important" });
          

            //In this case, there's a null value.
            var outcome4 = Outcomes.Success<ExampleConcrete>()
                                   .WithValue(null);

            //In this case, there's an incompatible type, so we should end up
            //without a value.
            var outcome5 = Outcomes.Success<string>()
                                   .WithValue("test");

            var from1 = Outcomes.Success().FromOutcome(outcome1);
            var from2 = Outcomes.Success().FromOutcome(outcome2);
            var from3 = Outcomes.Success<ExampleBase>().FromOutcome(outcome3);
            var from4 = Outcomes.Success<ExampleBase>().FromOutcome(outcome4);
            var from5 = Outcomes.Success<ExampleBase>().FromOutcome(outcome5);

            Assert.True(from1.Value.Equals(10));
            Assert.True((int) from1.Keys["StatusCode"] == 505);
            Assert.True(from2.Value.Equals(20));
            Assert.True(from2.Keys["StatusCode"] == null);
            Assert.True(from3.Value.SomeString == "not important");
            Assert.True(from3.Keys.ContainsKey("StatusCode") == false); // not set
            Assert.True(from4.Value == null);
            Assert.True(from5.Value == null);
        }

        [Fact]
        public void Success_WithValue_Works()
        {
            var outcome = Outcomes.Success<Decimal>(23123.32M);

            Assert.True(outcome.Success);
            Assert.True(outcome.Messages.Count == 0);
            Assert.True(outcome.Value == 23123.32M);
            Assert.True(outcome.ToString() == string.Empty);
            Assert.True(outcome.ToMultiLine("<br>") == string.Empty);
        }

        [Fact]
        public void Success_WithValue_And_Message_Works()
        {
            var outcome = Outcomes.Success<string>()
                                  .WithValue("9An@nsd!d")
                                  .WithMessage("Encrypted value retrieved in 5s!");

            Assert.True(outcome.Success);
            Assert.True(outcome.Value == "9An@nsd!d");
            Assert.True(outcome.Messages.Count == 1);
            Assert.True(outcome.ToMultiLine() == "Encrypted value retrieved in 5s!");
        }

        [Fact]
        public void Success_WithValue_Works_Even_If_Generic_Not_Specified()
        {
            var outcome = Outcomes.Success(23123.32M);

            Assert.True(outcome.Success);
            Assert.True(outcome.Messages.Count == 0);
            Assert.True(outcome.Value == 23123.32M);
            Assert.True(outcome.ToString() == string.Empty);
            Assert.True(outcome.ToMultiLine("<br>") == string.Empty);
        }

        [Fact]
        public void Success_Keys_WithKey_Works()
        {
            var outcome = Outcomes.Success(23123.32M)
                                  .WithKey("test1", "value1")
                                  .WithKey("test2", "value2");

            Assert.True((string) outcome.Keys["test1"] == "value1");
            Assert.True((string) outcome.Keys["test2"] == "value2");
        }
    }
}
