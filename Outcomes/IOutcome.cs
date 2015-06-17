using System.Collections.Generic;

namespace Ether.Outcomes
{
    public interface IOutcome<TValue> : IOutcome
    {
        TValue Value { get; }
    }

    public interface IOutcome
    {
        int? StatusCode { get; } 
        bool Success { get; }
        List<string> Messages { get; }
        string ToMultiLine(string delimiter = null);
        string ToString();
    }
}