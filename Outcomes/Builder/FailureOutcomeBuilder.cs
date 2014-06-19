using System;
using System.Collections.Generic;

namespace Ether.Outcomes.Builder
{
    public class FailureOutcomeBuilder<T> : SuccessOutcomeBuilder<T>, IFailureOutcomeBuilder<T>
    {
        internal FailureOutcomeBuilder(bool success) : base(success)
        {
        }

        public IFailureOutcomeBuilder<T> FromException(Exception exception, string message = null)
        {
            if (message != null)
                Messages.Add(message);

            base.Messages.Add("Exception: " + exception.Message);
            return this; 
        }

        public IFailureOutcomeBuilder<T> FromOutcome(IOutcome outcome, string message = null)
        {
            if(outcome.Success)
                throw new InvalidOperationException("When creating a failure outcome, and calling FromOutcome, Outcome.Success was True. This is not allowed.");

            if (message != null)
                Messages.Add(message);

            base.WithMessage(outcome.Messages);
            return this;
        }

        public new IFailureOutcomeBuilder<T> WithMessage(string message)
        {
            base.WithMessage(message);
            return this; 
        }

        public new IFailureOutcomeBuilder<T> WithMessage(IEnumerable<string> messages)
        {
            base.WithMessage(messages);
            return this;
        }
    }
}
