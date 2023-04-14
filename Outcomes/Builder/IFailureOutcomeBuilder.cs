using System;
using System.Collections.Generic;

namespace Ether.Outcomes.Builder
{
    public interface IFailureOutcomeBuilder<TValue> : IOutcome<TValue>
    {
        /// <summary>
        /// Adds an exception's message to the outcome's message collection. 
        /// </summary>
        /// <param name="exception">The exception to record.</param>
        /// <returns></returns>
        IFailureOutcomeBuilder<TValue> FromException(Exception exception);

        /// <summary>
        /// Add an outcome's message to the message list.
        /// Useful for unwinding deep calls where several methods have something to add about the failure. 
        /// </summary>
        /// <param name="outcome">A failure outcome.</param>
        /// <returns></returns>
        IFailureOutcomeBuilder<TValue> FromOutcome(IOutcome outcome);

        /// <summary>
        /// Add a string to the beginning of the outcome's message collection. Useful for adding
        /// context to an existing Outcome before passing it back up the stack.
        /// </summary>
        /// <param name="message">String to add.</param>
        /// <returns></returns>
        IFailureOutcomeBuilder<TValue> PrependMessage(string message);


        /// <summary>
        /// Add a string to the end of the outcome's message collection.
        /// </summary>
        /// <param name="message">String to add. It can contains string format pattern which will be used by string.Format.</param>
        /// <param name="paramList">Shorthand for String.Format</param>
        /// <returns></returns>
        IFailureOutcomeBuilder<TValue> WithMessageFormat(string message, params object[] paramList);

		/// <summary>
		/// Add a string to the end of the outcome's message collection.
		/// </summary>
		/// <param name="message">String to add.</param>
		/// <returns></returns>
		IFailureOutcomeBuilder<TValue> WithMessage(string message);
        /// <summary>
		/// Append a list of strings to the end of the outcome's message collection.
		/// </summary>
		/// <param name="messages">The strings to add.</param>
		/// <returns></returns>
		IFailureOutcomeBuilder<TValue> WithMessage(IEnumerable<string> messages);

        /// <summary>
        /// Alternate syntax for FromOutcome. Adds messages from the specified outcome (if any).
        /// </summary>
        /// <param name="outcome">Source outcome that messages are pulled from.</param>
        IFailureOutcomeBuilder<TValue> WithMessagesFrom(IOutcome outcome);

        /// <summary>
        /// Alternate syntax for WithMessage. Adds messages to the end of the message collection.
        /// </summary>
        IFailureOutcomeBuilder<TValue> WithMessagesFrom(IEnumerable<string> messages);

        /// <summary>
        /// Sets the value for a failure outcome. The outcome object is just a wrapper for the value.
        /// </summary>
        /// <param name="value">Specifies the value to wrap.</param>
        IFailureOutcomeBuilder<TValue> WithValue(TValue value);

        IFailureOutcomeBuilder<TValue> WithKeysFrom(IOutcome outcome);

        IFailureOutcomeBuilder<TValue> WithKey(string key, object value);
    }
}