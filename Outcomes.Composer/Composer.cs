using System;
namespace Ether.Outcomes.Composer
{
    public static class Composer
    {
        public static OutcomeStep<T> Execute<T>(Func<IOutcome<T>> expression)
        {
            IOutcome<T> outcome = expression();

            return new OutcomeStep<T>(outcome, true);
        }

        public static OutcomeStep<object> Execute(Func<IOutcome> expression)
        {
            IOutcome outcome = expression();

            //this should happen inside an overload of OutcomeStep's constructor,
            //but due to peculiarities of generics, that didn't work.
            var result = new OutcomeResult<object>(outcome);

            return new OutcomeStep<object>(result, true);
        }
    }

}
