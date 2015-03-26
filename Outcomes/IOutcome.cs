using System.Collections.Generic;

namespace Ether.Outcomes
{
    public interface IOutcome<T> : IOutcome
    {
        T Value { get; }
    }

    public interface IOutcome
    {
        bool Success { get; }
        List<string> Messages { get; }
        string FormatMultiLine(string delimiter);
        string ToString(string delimiter);
        string ToString();
    }
}