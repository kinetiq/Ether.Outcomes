using System;
using System.Collections.Generic;

namespace Ether.Outcomes.Builder
{
    public interface IFailureOutcomeBuilder<T> : IOutcome<T>
    {
        /// <summary>
        /// Adds an exception's message to the outcome's message collection. 
        /// </summary>
        /// <param name="exception">The exception to record.</param>
        /// <param name="message">Optional note that will show up before the exception's message.</param>
        /// <returns></returns>
        IFailureOutcomeBuilder<T> FromException(Exception exception, string message = null);

        /// <summary>
        /// Add an outcome's message to this outcome's message collection.
        /// Useful for unwinding deep calls where several methods have something to add about the failure. 
        /// </summary>
        /// <param name="outcome">A failure outcome.</param>
        /// <param name="message">Optional message to add before the source outcome's message.</param>
        /// <returns></returns>
        IFailureOutcomeBuilder<T> FromOutcome(IOutcome outcome, string message = null);

        /// <summary>
        /// Add a string to the end of the outcome's message collection.
        /// </summary>
        /// <param name="message">String to add.</param>
        /// <returns></returns>
        IFailureOutcomeBuilder<T> WithMessage(string message);

        /// <summary>
        /// Append a list of strings to the end of the outcome's message collection.
        /// </summary>
        /// <param name="messages">The strings to add.</param>
        /// <returns></returns>
        IFailureOutcomeBuilder<T> WithMessage(IEnumerable<string> messages);
    }
}