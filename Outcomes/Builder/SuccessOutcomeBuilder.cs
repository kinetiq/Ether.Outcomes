﻿using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Ether.Outcomes.Builder
{
    /// <summary>
    /// Uses the builder pattern to create a fluent interface for success scenarios.
    /// </summary>
    public class SuccessOutcomeBuilder<TValue> : OutcomeResult<TValue>
    {
        internal SuccessOutcomeBuilder(bool success) : base(success)
        {
        }

        /// <summary>
        /// Add a string to the beginning of the outcome's message collection. Useful for adding
        /// context to an existing Outcome before passing it back up the stack.
        /// </summary>
        /// <param name="message">String to add.</param>
        /// <returns></returns>
        public SuccessOutcomeBuilder<TValue> PrependMessage(string message)
        {
            base.Messages.Insert(0, message);
            return this;
        }

        /// <summary>
        /// Add a formatted string to the end of the outcome's message collection.
        /// </summary>
        /// <param name="message">String with format pattern to add. The format patterns will be used in string.Format.</param>
        /// <param name="paramList">Shorthand for String.Format</param>
        /// <returns></returns>
        [StringFormatMethod("message")]
        public SuccessOutcomeBuilder<TValue> WithMessageFormat(string message, params object[] paramList)
        {
            message = string.Format(message, paramList);

            base.Messages.Add(message);
            return this;
        }

		/// <summary>
		/// Add a string to the end of the outcome's message collection.
		/// </summary>
		/// <param name="message">String to add.</param>
		/// <returns></returns>
		public SuccessOutcomeBuilder<TValue> WithMessage(string message)
	    {
			base.Messages.Add(message);
		    return this;
	    }

        /// <summary>
        /// Append a list of strings to the end of the outcome's message collection.
        /// </summary>
        /// <param name="messages">Enum of strings to add.</param>
        /// <returns></returns>
        public SuccessOutcomeBuilder<TValue> WithMessage(IEnumerable<string> messages)
        {
            if (messages == null)
                return this;

            base.Messages.AddRange(messages);
            return this;
        }

        /// <summary>
        /// Adds messages from the specified outcome, if any.
        /// </summary>
        /// <param name="outcome">Source outcome that messages are pulled from.</param>
        public SuccessOutcomeBuilder<TValue> WithMessagesFrom(IOutcome outcome)
        {
            WithMessage(outcome.Messages);
            return this;
        }

        /// <summary>
        /// Alternate syntax for WithMessage. Adds a collection of messages to the end of the outcome's message list. 
        /// </summary>
        public SuccessOutcomeBuilder<TValue> WithMessagesFrom(IEnumerable<string> messages)
        {
            WithMessage(messages);
            return this;
        }

        /// <summary>
        /// Sets the value for a success outcome. The outcome object is just a wrapper for the value.
        /// </summary>
        /// <param name="value">Specifies the value to wrap.</param>
        /// <returns></returns>
        public SuccessOutcomeBuilder<TValue> WithValue(TValue value)
        {
            base.Value = value;
            return this;
        }

        /// <summary>
        /// Adds keys from the specified outcome, if any.
        /// </summary>
        /// <param name="outcome">Source outcome that messages are pulled from.</param>
        public SuccessOutcomeBuilder<TValue> WithKeysFrom(IOutcome outcome)
        {
            foreach (var key in outcome.Keys.Keys)
                this.Keys[key] = outcome.Keys[key];

            return this;
        }

        /// <summary>
        /// (optional) Sets a key value pair, which is additional metadata you can use for your own purposes. 
        /// This is handy for status codes, or any case where you need to return more than one value. 
        /// </summary>
        public SuccessOutcomeBuilder<TValue> WithKey(string key, object value)
        {
            base.Keys[key] = value;
            return this;
        }

        /// <summary>
        /// Adds messages and keys from the specified outcome.
        /// </summary>
        /// <param name="outcome">Source outcome that keys are pulled from.</param>
        public SuccessOutcomeBuilder<TValue> FromOutcome(IOutcome outcome)
        {
            WithMessage(outcome.Messages);
            WithKeysFrom(outcome);

            //If outcome has a Value, and if we can coerce it into TValue, 
            //we should do so.     
            var type = outcome.GetType();
            var info = type.GetTypeInfo();

            if (info.IsGenericType) //only generics have Value 
            {
                    //get the contents of value
                var value = type
                    .GetRuntimeProperty("Value")
                    .GetValue(outcome, null);

                if (value is TValue matchedValue) //are these types compatible? 
                    WithValue(matchedValue); //if so, caste and assign.
            }
            
            return this;
        }
    }
}
