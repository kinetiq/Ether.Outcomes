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
    }
}
