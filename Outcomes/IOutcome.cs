using System.Collections.Generic;

namespace Ether.Outcomes
{
    public interface IOutcome<TValue> : IOutcome
    {
        TValue Value { get; }
    }

    public interface IOutcome<TValue, TStatusCode> : IOutcome<TValue>
    {
        TStatusCode StatusCode { get; }
    }

    public interface IOutcome
    {
        bool Success { get; }
        List<string> Messages { get; }
        string FormatMultiLine(string delimiter);
        string ToString();
    }
}