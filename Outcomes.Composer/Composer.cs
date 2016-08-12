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

        public static OutcomeStep<object> Execute(Func<IOutcome<object>> expression)
        {
            return Execute<object>(expression);
        }
    }

}
