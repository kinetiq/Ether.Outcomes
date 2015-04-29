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
        public static SuccessOutcomeBuilder<object, int?> Success()
        {
            return new SuccessOutcomeBuilder<object, int?>(success: true);
        }

        public static SuccessOutcomeBuilder<TValue, int?> Success<TValue>()
        {
            return new SuccessOutcomeBuilder<TValue, int?>(success: true);
        }

        /// <summary>
        /// Returns an IOutcome with Success = true and sets the value. 
        /// </summary>
        public static SuccessOutcomeBuilder<object, int?> Success(object value)
        {
            return new SuccessOutcomeBuilder<object, int?>(success: true).WithValue(value);
        }

        /// <summary>
        /// Returns an IOutcome with Success = true and sets the value. 
        /// </summary>
        public static SuccessOutcomeBuilder<TValue, int?> Success<TValue>(TValue value)
        {
            return new SuccessOutcomeBuilder<TValue, int?>(success: true).WithValue(value);
        }

        /// <summary>
        /// Returns an IOutcome with Success = true and a generic status code.
        /// </summary>
        public static SuccessOutcomeBuilder<TValue, TStatusCode> Success<TValue, TStatusCode>()
        {
            return new SuccessOutcomeBuilder<TValue, TStatusCode>(success: true);
        }  

        /// <summary>
        /// Returns an IOutcome with Success = true and a generic status code, and sets the value. 
        /// </summary>
        public static SuccessOutcomeBuilder<TValue, TStatusCode> Success<TValue, TStatusCode>(TValue value)
        {
            return new SuccessOutcomeBuilder<TValue, TStatusCode>(success: true).WithValue(value);
        }  
    }

    //Partial class contains all the failure-related methods.
    public static partial class Outcomes
    {
        public static IFailureOutcomeBuilder<object, int?> Failure()
        {
            return new FailureOutcomeBuilder<object, int?>(success: false);
        }

        public static IFailureOutcomeBuilder<TValue, int?> Failure<TValue>()
        {
            return new FailureOutcomeBuilder<TValue, int?>(success: false);
        }

        /// <summary>
        /// Returns an IOutcome with a generic status code.
        /// </summary>
        public static FailureOutcomeBuilder<TValue, TStatusCode> Failure<TValue, TStatusCode>()
        {
            return new FailureOutcomeBuilder<TValue, TStatusCode>(success: true);
        }  
    }
}
