using System;
using System.Threading.Tasks;
using static Ether.Outcomes.Outcomes;

namespace Ether.Outcomes
{
    public static class FluentExtensions
    {
        public static IOutcome OnSuccess(this IOutcome outcome, Func<IOutcome> mapper)
        {
            if (outcome.Success)
                return mapper();

            return outcome;
        }

        public static async Task<IOutcome> OnSuccess(this IOutcome outcome, Func<Task<IOutcome>> mapper)
        {
            if (outcome.Success)
                return await mapper();

            return outcome;
        }

        public static async Task<IOutcome> OnSuccess(this Task<IOutcome> outcome, Func<Task<IOutcome>> mapper)
        {
            var awaitedOutcome = await outcome;

            if (awaitedOutcome.Success)
                return await mapper();

            return awaitedOutcome;
        }

        public static async Task<IOutcome> OnSuccess<TIn>(this IOutcome<TIn> outcome, Func<TIn, Task<IOutcome>> mapper)
        {
            if (outcome.Success)
                return await mapper(outcome.Value);

            return outcome;
        }

        public static IOutcome<TOut> OnSuccess<TOut>(this IOutcome outcome, Func<IOutcome<TOut>> mapper)
        {
            if (outcome.Success)
                return mapper();

            return Failure<TOut>().FromOutcome(outcome);
        }

        public static async Task<IOutcome<TOut>> OnSuccess<TOut>(this IOutcome outcome, Func<Task<IOutcome<TOut>>> mapper)
        {
            if (outcome.Success)
                return await mapper();

            return Failure<TOut>().FromOutcome(outcome);
        }

        public static IOutcome<TOut> OnSuccess<TIn, TOut>(this IOutcome<TIn> outcome, Func<TIn, IOutcome<TOut>> mapper)
        {
            if (outcome.Success)
                return mapper(outcome.Value);

            return Failure<TOut>().FromOutcome(outcome);
        }

        public static async Task<IOutcome<TOut>> OnSuccess<TIn, TOut>(this IOutcome<TIn> outcome, Func<TIn, Task<IOutcome<TOut>>> mapper)
        {
            if (outcome.Success)
                return await mapper(outcome.Value);

            return Failure<TOut>().FromOutcome(outcome);
        }

        public static async Task<IOutcome<TOut>> OnSuccess<TIn, TOut>(this Task<IOutcome<TIn>> outcome, Func<TIn, Task<IOutcome<TOut>>> mapper)
        {
            var awaitedOutcome = await outcome;

            if (awaitedOutcome.Success)
                return await mapper(awaitedOutcome.Value);

            return Failure<TOut>().FromOutcome(awaitedOutcome);
        }

        public static async Task<IOutcome<TOut>> OnSuccess<TIn, TOut>(this Task<IOutcome<TIn>> outcome, Func<TIn, IOutcome<TOut>> mapper)
        {
            var awaitedOutcome = await outcome;

            if (awaitedOutcome.Success)
                return mapper(awaitedOutcome.Value);

            return Failure<TOut>().FromOutcome(awaitedOutcome);
        }

        public static async Task<IOutcome> OnSuccess<TIn>(this Task<IOutcome<TIn>> outcome, Func<TIn, IOutcome> mapper)
        {
            var awaitedOutcome = await outcome;

            if (awaitedOutcome.Success)
                return mapper(awaitedOutcome.Value);

            return awaitedOutcome;
        }

        public static IOutcome OnFailure(this IOutcome outcome, Func<IOutcome> mapper)
        {
            if (outcome.Failure)
                return mapper();

            return outcome;
        }

        public static async Task<IOutcome> OnFailure(this IOutcome outcome, Func<Task<IOutcome>> mapper)
        {
            if (outcome.Failure)
                return await mapper();

            return outcome;
        }

        public static async Task<IOutcome> OnFailure(this Task<IOutcome> outcome, Func<Task<IOutcome>> mapper)
        {
            var awaitedOutcome = await outcome;

            if (awaitedOutcome.Failure)
                return await mapper();

            return awaitedOutcome;
        }

        public static async Task<IOutcome> OnFailure<TIn>(this IOutcome<TIn> outcome, Func<TIn, Task<IOutcome>> mapper)
        {
            if (outcome.Failure)
                return await mapper(outcome.Value);

            return outcome;
        }

        public static IOutcome<TOut> OnFailure<TOut>(this IOutcome outcome, Func<IOutcome<TOut>> mapper)
        {
            if (outcome.Failure)
                return mapper();

            return Success<TOut>().FromOutcome(outcome);
        }

        public static async Task<IOutcome<TOut>> OnFailure<TOut>(this IOutcome outcome, Func<Task<IOutcome<TOut>>> mapper)
        {
            if (outcome.Failure)
                return await mapper();

            return Success<TOut>().FromOutcome(outcome);
        }

        public static IOutcome<TOut> OnFailure<TIn, TOut>(this IOutcome<TIn> outcome, Func<TIn, IOutcome<TOut>> mapper)
        {
            if (outcome.Failure)
                return mapper(outcome.Value);

            return Success<TOut>().FromOutcome(outcome);
        }

        public static async Task<IOutcome<TOut>> OnFailure<TIn, TOut>(this IOutcome<TIn> outcome, Func<TIn, Task<IOutcome<TOut>>> mapper)
        {
            if (outcome.Failure)
                return await mapper(outcome.Value);

            return Success<TOut>().FromOutcome(outcome);
        }

        public static async Task<IOutcome<TOut>> OnFailure<TIn, TOut>(this Task<IOutcome<TIn>> outcome, Func<TIn, Task<IOutcome<TOut>>> mapper)
        {
            var awaitedOutcome = await outcome;

            if (awaitedOutcome.Failure)
                return await mapper(awaitedOutcome.Value);

            return Success<TOut>().FromOutcome(awaitedOutcome);
        }

        public static async Task<IOutcome<TOut>> OnFailure<TIn, TOut>(this Task<IOutcome<TIn>> outcome, Func<TIn, IOutcome<TOut>> mapper)
        {
            var awaitedOutcome = await outcome;

            if (awaitedOutcome.Failure)
                return mapper(awaitedOutcome.Value);

            return Success<TOut>().FromOutcome(awaitedOutcome);
        }

        public static async Task<IOutcome> OnFailure<TIn>(this Task<IOutcome<TIn>> outcome, Func<TIn, IOutcome> mapper)
        {
            var awaitedOutcome = await outcome;

            if (awaitedOutcome.Failure)
                return mapper(awaitedOutcome.Value);

            return awaitedOutcome;
        }
    }
}
