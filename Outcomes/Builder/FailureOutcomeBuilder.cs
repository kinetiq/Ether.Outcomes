using System;
using System.Collections.Generic;

namespace Ether.Outcomes.Builder
{
    /// <summary>
    /// Uses the builder pattern to create a fluent interface for failure scenarios.
    /// </summary>
    public class FailureOutcomeBuilder<TValue> : SuccessOutcomeBuilder<TValue>, IFailureOutcomeBuilder<TValue>
    {
        internal FailureOutcomeBuilder(bool success) : base(success)
        {
        }

        /// <summary>
        /// Adds messages from the specified exception. Internally, Outcome.Net calls exception.Message to generate the messages.
        /// </summary>
        /// <param name="exception">Exception used to generate the message.</param>
        /// <param name="message">Optional message that will appear after the exception's messages.</param>
        /// <param name="paramList">Shorthand for String.Format</param>
        public IFailureOutcomeBuilder<TValue> FromException(Exception exception, string message = null, params object[] paramList)
        {
            if (message != null)
            {
                message = string.Format(message, paramList);
                Messages.Add(message);
            } 

            base.Messages.Add("Exception: " + exception.Message);
            return this; 
        }

        /// <summary>
        /// Adds messages from the specified outcome.
        /// </summary>
        /// <param name="outcome">Source outcome that messages are pulled from. If there are no messages, execution continues.</param>
        /// <param name="message">Optional message that will appear after the specified outcome's messages.</param>
        /// <param name="paramList">Shorthand for String.Format</param>
        public IFailureOutcomeBuilder<TValue> FromOutcome(IOutcome outcome, string message = null, params object[] paramList)
        {
            if (message != null)
            {
                message = string.Format(message, paramList);
                Messages.Add(message);
            } 

            base.WithMessage(outcome.Messages);
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
        /// Alternate syntax for FromOutcome. Adds messages from the specified outcome, if any.
        /// </summary>
        /// <param name="outcome">Source outcome that messages are pulled from.</param>
        /// <param name="message">Optional message that will appear after the specified outcome's messages.</param>
        /// <param name="paramList">Shorthand for String.Format</param>
        public IFailureOutcomeBuilder<TValue> WithMessagesFrom(IOutcome outcome, string message = null, params object[] paramList)
        {
            FromOutcome(outcome, message, paramList);
            return this;
        }

        /// <summary>
        /// Alternate syntax for WithMessage. Adds a collection of messages to the end of the outcome's message list. 
        /// </summary>
        public IFailureOutcomeBuilder<TValue> WithMessagesFrom(IEnumerable<string> messages)
        {
            base.WithMessage(messages);
            return this;
        }

        public new IFailureOutcomeBuilder<TValue> WithStatusCode(int? statusCode)
        {
            base.WithStatusCode(statusCode);
            return this;
        }
    }
}
