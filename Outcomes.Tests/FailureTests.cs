using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;


namespace Ether.Outcomes.Tests
{

    public class FailureTests
    {
        [Fact]
        public void Failure_Messages_Not_Null_By_Default()
        {
            IOutcome outcome = Outcomes.Failure();

            Assert.False(outcome.Success);
            Assert.NotNull(outcome.Messages);
            Assert.True(outcome.ToString() == string.Empty);

            //This should also work.
            IOutcome<object> o = (IOutcome<object>) outcome;
            Assert.Null(o.Value);

        }

        [Fact]
        public void Failure_OfT_Messages_Not_Null_By_Default()
        {
            IOutcome<int> outcome = Outcomes.Failure<int>();

            Assert.False(outcome.Success);
            Assert.NotNull(outcome.Messages);
            Assert.True(outcome.Value == 0);
            Assert.True(outcome.ToString() == string.Empty);       
        }

        [Fact]
        public void Failure_Basic_Chaining_Works()
        {
            var messages = new List<string> { "test2", "test3" };

            var outcome = Outcomes.Failure<int>().WithMessage("test1")
                                                 .WithMessage(messages);

            Assert.False(outcome.Success);
            Assert.True(outcome.Value == 0);
            Assert.True(outcome.Messages.Count == 3);
            Assert.True(outcome.ToString() == "test1test2test3");
            Assert.True(outcome.ToMultiLine("<br>") == "test1<br>test2<br>test3<br>");
        }

        [Fact]
        public void Failure_Messages_Prepend_Works()
        {
            IOutcome outcome = Outcomes.Success()
                .WithMessage("Test!");

            var newOutcome = Outcomes.Failure()
                .FromOutcome(outcome)
                .PrependMessage("This should be first since it's prepended!");

            Assert.True(newOutcome.Failure);
            Assert.True(newOutcome.Messages.Count == 2);
            Assert.True(newOutcome.Messages[0] == "This should be first since it's prepended!");
            Assert.True(newOutcome.Messages[1] == "Test!");
        }

        [Fact]
        public void Failure_Chaining_With_Syntactic_Sugar_Works()
        {
            var messages = new List<string> { "test2", "test3" };

            var outcome = Outcomes.Failure<int>().WithMessage("test1")                                                
                                                 .WithMessagesFrom(messages);

            Assert.False(outcome.Success);
            Assert.True(outcome.Value == 0);
            Assert.True(outcome.Messages.Count == 3);
            Assert.True(outcome.ToString() == "test1test2test3");
            Assert.True(outcome.ToMultiLine("<br>") == "test1<br>test2<br>test3<br>");
        }


        [Fact]
        public void Failure_WithKeysFrom_Works()
        {
            var outcome1 = Outcomes.Failure()
                                   .WithKey("test", 35);

            var outcome2 = Outcomes.Failure().WithKeysFrom(outcome1);
            var outcome3 = Outcomes.Failure().FromOutcome(outcome1);

            Assert.True(outcome1.Keys["test"].Equals(35));
            Assert.True(outcome2.Keys["test"].Equals(35));
            Assert.True(outcome3.Keys["test"].Equals(35));
        }


        [Fact]
        public void Failure_FromException_Works()
        {
            var exception = new InvalidOperationException("test message");

            var outcome = Outcomes.Failure().FromException(exception);

            Assert.False(outcome.Success);
            Assert.True(outcome.Messages.Count == 1);
            Assert.True(outcome.ToMultiLine("<br>") == "System.InvalidOperationException: test message<br>");
        }


        [Fact]
        public void Failure_FromException_Chaining_Works()
        {
            var exception = new InvalidOperationException("test");

            var outcome = Outcomes.Failure().WithMessage("prefix")
                                            .FromException(exception)
                                            .WithMessage("suffix");
            Assert.False(outcome.Success);
            Assert.True(outcome.Messages.Count == 3);
            Assert.True(outcome.ToMultiLine("<br>") == "prefix<br>System.InvalidOperationException: test<br>suffix<br>");
        }

        [Fact]
        public void Failure_FromOutcome_Chaining_Works()
        {
            var previousOutcome = Outcomes.Failure().WithMessage("test");

            var outcome = Outcomes.Failure().WithMessage("prefix")
                                            .FromOutcome(previousOutcome)
                                            .WithMessage("suffix");

            Assert.False(outcome.Success);
            Assert.True(outcome.Messages.Count == 3);
            Assert.True(outcome.ToMultiLine("<br>") == "prefix<br>test<br>suffix<br>");
        }

        [Fact]
        public void Failure_Chaining_Syntactic_Sugar_Works()
        {
            var previousOutcome = Outcomes.Failure().WithMessage("test");

            var outcome = Outcomes.Failure().WithStatusCode(201)
                                            .WithMessage("prefix")
                                            .WithMessagesFrom(previousOutcome)
                                            .WithMessage("suffix");
            

            Assert.False(outcome.Success);
            Assert.True(outcome.Messages.Count == 3);
            Assert.True(outcome.ToMultiLine("<br>") == "prefix<br>test<br>suffix<br>");
        }


        [Fact]
        public void Failure_StatusCode_Is_NullByDefault()
        {
            var outcome = Outcomes.Failure();

            Assert.Null(outcome.StatusCode);
        }

        [Fact]
        public void Failure_StatusCode_WithStatusCode_Works()
        {
            var outcome = Outcomes.Failure()
                                  .WithStatusCode(200);

            Assert.True(outcome.StatusCode == 200);
        }

        [Fact]
        public void Failure_WithValue_Works()
        {
            var outcome = Outcomes.Failure<Decimal>()
                                  .WithValue(23123.32M);

            Assert.True(!outcome.Success);
            Assert.True(outcome.Messages.Count == 0);
            Assert.True(outcome.Value == 23123.32M);
            Assert.True(outcome.ToString() == string.Empty);
            Assert.True(outcome.ToMultiLine("<br>") == string.Empty);
        }

        [Fact]
        public void Failure_Keys_WithKey_Works()
        {
            var outcome = Outcomes.Failure()
                                  .WithKey("test1", "value1")
                                  .WithKey("test2", "value2");

            Assert.True(outcome.Keys["test1"].ToString() == "value1");
            Assert.True(outcome.Keys["test2"].ToString() == "value2");
        }
    }
}
