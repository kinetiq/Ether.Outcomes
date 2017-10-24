using Ether.Outcomes.Builder;

namespace Ether.Outcomes
{

    //Partial class contains all the success-related methods.
    public static partial class Outcomes
    {
        public static SuccessOutcomeBuilder<object> Success()
        {
            return new SuccessOutcomeBuilder<object>(success: true);
        }

        public static SuccessOutcomeBuilder<TValue> Success<TValue>()
        {
            return new SuccessOutcomeBuilder<TValue>(success: true);
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
        public static SuccessOutcomeBuilder<TValue> Success<TValue>(TValue value)
        {
            return new SuccessOutcomeBuilder<TValue>(success: true).WithValue(value);
        }
    }

    //Partial class contains all the failure-related methods.
    public static partial class Outcomes
    {
        public static IFailureOutcomeBuilder<object> Failure()
        {
            return new FailureOutcomeBuilder<object>(success: false);
        }

        public static IFailureOutcomeBuilder<TValue> Failure<TValue>()
        {
            return new FailureOutcomeBuilder<TValue>(success: false);
        }
    }
}
