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
    }
}
