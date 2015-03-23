using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Ether.Outcomes.Builder;
using JetBrains.Annotations;

namespace Ether.Outcomes
{

    //Partial class contains all the success-related methods.
    public static partial class Outcomes
    {
        public static SuccessOutcomeBuilder<object> Success()
        {
            return new SuccessOutcomeBuilder<object>(success: true);
        }

        public static SuccessOutcomeBuilder<T> Success<T>()
        {
            return new SuccessOutcomeBuilder<T>(success: true);
        }

        /// <summary>
        /// Returns an IOutcome with Success = true and sets the value. 
        /// </summary>
        public static SuccessOutcomeBuilder<object> Success(object value)
        {
            return new SuccessOutcomeBuilder<object>(success: true).WithValue(value);
        }

        /// <summary>
        /// Returns an IOutcome with Success = true and sets the value. 
        /// </summary>
        public static SuccessOutcomeBuilder<T> Success<T>(T value)
        {
            return new SuccessOutcomeBuilder<T>(success: true).WithValue(value);
        }

        /// <summary>
        /// Returns an IOutcome with Success = true, sets the value, and adds a message.
        /// </summary>
        [StringFormatMethod("message")]
        [Obsolete("This method is deprecated for clarity and will be removed in Outcomes 2. Please make a seperate call to .WithMessage")]
        public static SuccessOutcomeBuilder<object> Success(object value, string message, params object[] paramList)
        {
            return new SuccessOutcomeBuilder<object>(success: true).WithValue(value)
                                                                   .WithMessage(message, paramList);
        }

        /// <summary>
        /// Returns an IOutcome with Success = true, sets the value, and adds a message.
        /// </summary>
        [StringFormatMethod("message")]
        [Obsolete("This method is deprecated for clarity and will be removed in Outcomes 2. Please make a seperate call to .WithMessage")]       
        public static SuccessOutcomeBuilder<T> Success<T>(T value, string message, params object[] paramList)
        {
            return new SuccessOutcomeBuilder<T>(success: true).WithValue(value)
                                                              .WithMessage(message, paramList);
        }       
    }

    //Partial class contains all the failure-related methods.
    public static partial class Outcomes
    {
        public static IFailureOutcomeBuilder<object> Failure()
        {
            return new FailureOutcomeBuilder<object>(success: false);
        }

        public static IFailureOutcomeBuilder<T> Failure<T>()
        {
            return new FailureOutcomeBuilder<T>(success: false);
        }

        /// <summary>
        /// Returns an IOutcome with Success = false and sets the message.
        /// </summary>
        [StringFormatMethod("message")]
        [Obsolete("This method is deprecated for clarity and will be removed in Outcomes 2. Please make seperate calls to .WithMessage")]  
        public static IFailureOutcomeBuilder<object> Failure(string message, params object[] paramList)
        {
            return new FailureOutcomeBuilder<object>(success: false).WithMessage(message, paramList);
        }

        /// <summary>
        /// Returns an IOutcome with Success = false and sets the message.
        /// </summary>
        [StringFormatMethod("message")]
        [Obsolete("This method is deprecated for clarity and will be removed in Outcomes 2. Please make seperate calls to .WithMessage")]
        public static IFailureOutcomeBuilder<T> Failure<T>(string message, params object[] paramList)
        {
            return new FailureOutcomeBuilder<T>(success: false).WithMessage(message, paramList);
        }

        /// <summary>
        /// Returns an IOutcome with Success = false and sets the message from an exception.
        /// </summary>
        [StringFormatMethod("message")]
        [Obsolete("This method is deprecated for clarity and will be removed in Outcomes 2. Please make seperate calls to .WithException and .WithMessage")]       
        public static IFailureOutcomeBuilder<object> Failure(Exception exception, string message = null, params object[] paramList)
        {
            return new FailureOutcomeBuilder<object>(success: false).FromException(exception, message, paramList);
        }

        /// <summary>
        /// Returns an IOutcome with Success = false and sets the message from an exception.
        /// </summary>
        [StringFormatMethod("message")]
        [Obsolete("This method is deprecated for clarity and will be removed in Outcomes 2. Please make seperate calls to .WithException and .WithMessage")]       
        public static IFailureOutcomeBuilder<T> Failure<T>(Exception exception, string message = null, params object[] paramList)
        {
            return new FailureOutcomeBuilder<T>(success: false).FromException(exception, message, paramList);
        }

        /// <summary>
        /// Returns an IOutcome with Success = false and sets the message from another outcome.
        /// </summary>
        [StringFormatMethod("message")]
        [Obsolete("This method is deprecated for clarity and will be removed in Outcomes 2. Please make seperate calls to .FromOutcome and .WithMessage")]             
        public static IFailureOutcomeBuilder<object> Failure(IOutcome outcome, string message = null, params object[] paramList)
        {
            return new FailureOutcomeBuilder<object>(success: false).FromOutcome(outcome, message, paramList);
        }

        /// <summary>
        /// Returns an IOutcome with Success = false and sets the message from another outcome.
        /// </summary>
        [StringFormatMethod("message")]
        [Obsolete("This method is deprecated for clarity and will be removed in Outcomes 2. Please make seperate calls to .FromOutcome and .WithMessage")]       
        public static IFailureOutcomeBuilder<T> Failure<T>(IOutcome outcome, string message = null, params object[] paramList)
        {
            return new FailureOutcomeBuilder<T>(success: false).FromOutcome(outcome, message);
        }
    }
}
