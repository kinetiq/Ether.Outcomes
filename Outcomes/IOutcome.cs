using System.Collections.Generic;

namespace Ether.Outcomes
{
    public interface IOutcome<TValue> : IOutcome
    {
        TValue Value { get; }
        int? StatusCode { get; } 
    }

    public interface IOutcome
    {
        bool Success { get; }
        List<string> Messages { get; }
        string ToMultiLine(string delimiter = null);
        string ToString();
    }
}