using System;
using System.Collections.Generic;

namespace Ether.Outcomes.Builder
{
    /// <summary>
    /// Uses the builder pattern to create a fluent interface for failure scenarios.
    /// </summary>
#if NET45 || NET40
    [Serializable]
#endif
    public class FailureOutcomeBuilder<TValue> : SuccessOutcomeBuilder<TValue>, IFailureOutcomeBuilder<TValue>
    {
        internal FailureOutcomeBuilder(bool success) : base(success)
        {
        }

        /// <summary>
        /// Adds messages from the specified exception. Internally, Outcome.Net calls exception.Message to generate the messages.
        /// </summary>
        /// <param name="exception">Exception used to generate the message.</param>
        public IFailureOutcomeBuilder<TValue> FromException(Exception exception)
        {
            base.Messages.Add("Exception: " + exception);
            return this; 
        }

        /// <summary>
        /// Adds messages and keys from the specified outcome.
        /// </summary>
        /// <param name="outcome">Source outcome that messages and keys are pulled from.</param>
        public new IFailureOutcomeBuilder<TValue> FromOutcome(IOutcome outcome)
        {
            base.FromOutcome(outcome);
            return this;
        }

        /// <summary>
        /// Adds a message to the end of the message list.
        /// </summary>
        /// <param name="message">Optional message that will appear after the specified outcome's messages.</param>
        /// <param name="paramList">Shorthand for String.Format</param>
        public new IFailureOutcomeBuilder<TValue> WithMessage(string message, params object[] paramList)
        {
            base.WithMessage(message, paramList);
            return this; 
        }

        /// <summary>
        /// Adds a collection of messages to the end of the outcome's message list.
        /// </summary>
        public new IFailureOutcomeBuilder<TValue> WithMessage(IEnumerable<string> messages)
        {
            base.WithMessage(messages);
            return this;
        }

        /// <summary>
        /// Adds messages from the specified outcome, if any.
        /// </summary>
        /// <param name="outcome">Source outcome that messages are pulled from.</param>
        public new IFailureOutcomeBuilder<TValue> WithMessagesFrom(IOutcome outcome)
        {
            base.WithMessage(outcome.Messages);
            return this;
        }

        /// <summary>
        /// Alternate syntax for WithMessage. Adds a collection of messages to the end of the outcome's message list. 
        /// </summary>
        public new IFailureOutcomeBuilder<TValue> WithMessagesFrom(IEnumerable<string> messages)
        {
            base.WithMessage(messages);
            return this;
        }

        [Obsolete("This will eventually be replaced by the new Keys dictionary.")]
        public new IFailureOutcomeBuilder<TValue> WithStatusCode(int? statusCode)
        {
            base.WithStatusCode(statusCode);
            return this;
        }

        /// <summary>
        /// Sets the value for a failure outcome. The outcome object is just a wrapper for the value.
        /// </summary>
        /// <param name="value">Specifies the value to wrap.</param>
        public new IFailureOutcomeBuilder<TValue> WithValue(TValue value)
        {
            base.WithValue(value);
            return this;
        }

        /// <summary>
        /// Adds keys from the specified outcome, if any.
        /// </summary>
        /// <param name="outcome">Source outcome that messages are pulled from.</param>
        public new IFailureOutcomeBuilder<TValue> WithKeysFrom(IOutcome outcome)
        {
            base.WithKeysFrom(outcome);

            return this;
        }

        /// <summary>
        /// (optional) Sets a key value pair, which is additional metadata you can use for your own purposes. 
        /// This is handy for status codes, or any case where you need to return more than one value. 
        /// </summary>
        public new IFailureOutcomeBuilder<TValue> WithKey(string key, object value)
        {
            base.WithKey(key, value);
            return this;
        }
    }
}
