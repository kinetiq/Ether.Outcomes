namespace Ether.Outcomes.Composer.Tests.Helpers
{
    public static class StaticHelpers
    {
        public static IOutcome<string> Success()
        {
            return Outcomes.Success<string>();
        }

        public static IOutcome<string> Fail()
        {
            return Outcomes.Failure<string>();
        }

        public static IOutcome NonGenericFail()
        {
            return Outcomes.Failure();
        }

        public static IOutcome NonGenericFailWithParam(int notUsed)
        {
            return Outcomes.Failure();
        }

        public static IOutcome<object> NonGenericFailObj()
        {
            return Outcomes.Failure();
        }

        public static IOutcome<object> GenericFailWithParam(int notUsed)
        {
            return Outcomes.Failure();
        }
    }
}
