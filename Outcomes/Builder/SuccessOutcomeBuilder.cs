using System;
using System.Collections.Generic;

namespace Ether.Outcomes.Builder
{
    /// <summary>
    /// Uses the builder pattern to create a fluent interface for success scenarios.
    /// </summary>
    public class SuccessOutcomeBuilder<T> : OutcomeResult<T>
    {
        internal SuccessOutcomeBuilder(bool success) : base(success)
        {
        }

        /// <summary>
        /// Add a string to the end of the outcome's message collection.
        /// </summary>
        /// <param name="message">String to add.</param>
        /// <param name="paramList">Shorthand for String.Format</param>
        /// <returns></returns>
        public SuccessOutcomeBuilder<T> WithMessage(string message, params object[] paramList)
        {
            message = string.Format(message, paramList);

            base.Messages.Add(message);
            return this;
        }

        /// <summary>
        /// Append a list of strings to the end of the outcome's message collection.
        /// </summary>
        /// <param name="messages">The strings to add.</param>
        /// <returns></returns>
        public SuccessOutcomeBuilder<T> WithMessage(IEnumerable<string> messages)
        {
            if (messages == null)
                return this;

            base.Messages.AddRange(messages);
            return this;
        }

        /// <summary>
        /// Sets the value for a success outcome. The outcome object is just a wrapper for the value.
        /// </summary>
        /// <param name="value">Specifies the value to wrap.</param>
        /// <returns></returns>
        public SuccessOutcomeBuilder<T> WithValue(T value)
        {
            base.Value = value;
            return this; 
        } 
    }
}
