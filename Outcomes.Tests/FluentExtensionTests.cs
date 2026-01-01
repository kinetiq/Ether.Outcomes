using System.Threading.Tasks;
using Xunit;
using Ether.Outcomes;
using System;

namespace Ether.Outcomes.Tests
{
    public class FluentExtensionTests
    {
        [Fact]
        public void OnSuccess_LastResultIsUsed()
        {
            var outcome = Outcomes.Success()
                .OnSuccess(() => Outcomes.Failure());

            Assert.True(outcome.Failure);
        }

        [Fact]
        public void OnSuccess_LastResultIsUsedForFailure()
        {
            var firstTestString = "babies";
            var secondTestString = "dolphins";

            var outcome = Outcomes.Success(firstTestString)
                .OnSuccess(_ => Outcomes.Success(secondTestString));

            Assert.Equal(secondTestString, outcome.Value);
        }

        [Fact]
        public void OnSuccess_FailureStopsPipeline()
        {
            var outcome = Outcomes.Success()
                .OnSuccess(() => Outcomes.Failure())
                .OnSuccess(() => Outcomes.Success());

            Assert.True(outcome.Failure);
        }

        [Fact]
        public async Task OnSuccess_AsyncReturnsTask()
        {
            var testString = "this is my payload";
            Func<string, Task<IOutcome<string>>> asyncValidator = async (a) => Outcomes.Success(a);

            var outcome = await Outcomes.Success(testString)
                .OnSuccess(asyncValidator)
                .OnSuccess((payload) => Outcomes.Success(payload));

            Assert.Equal(testString, outcome.Value);
        }

        [Fact]
        public void OnFailure_LastResultIsUsed()
        {
            var outcome = Outcomes.Failure()
                .OnFailure(() => Outcomes.Success());

            Assert.True(outcome.Success);
        }

        [Fact]
        public void OnFailure_LastResultIsUsedForFailure()
        {
            var firstTestString = "babies";
            var secondTestString = "dolphins";

            var outcome = Outcomes.Failure<string>().WithValue(firstTestString)
                .OnFailure(_ => Outcomes.Failure<string>().WithValue(secondTestString));

            Assert.Equal(secondTestString, outcome.Value);
        }

        [Fact]
        public void OnFailure_SuccessStopsPipeline()
        {
            var outcome = Outcomes.Failure()
                .OnFailure(() => Outcomes.Success())
                .OnFailure(() => Outcomes.Failure());

            Assert.True(outcome.Success);
        }

        [Fact]
        public async Task OnFailure_AsyncReturnsTask()
        {
            var testString = "baby dolphins";
            Func<string, Task<IOutcome<string>>> asyncValidator = async (a) =>
                Outcomes.Failure<string>().WithValue(a);

            var outcome = await Outcomes.Failure<string>().WithValue(testString)
                .OnFailure(asyncValidator)
                .OnFailure((payload) => Outcomes.Failure().WithValue(payload));

            Assert.Equal(testString, outcome.Value);
        }
    }
}
