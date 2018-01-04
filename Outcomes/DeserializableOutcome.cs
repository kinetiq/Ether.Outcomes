using Ether.Outcomes.Formats;
using System;
using System.Collections.Generic;

namespace Ether.Outcomes
{
    /// <summary>
    /// This class is intended for cases where you need to deserialize an Outcome using 
    /// libraries like RestSharp, ServiceStack.Text, or Json.Net.
    /// 
    /// Do not use this class to instantiate new Outcomes of your own. Use the Outcomes API instead.
    /// </summary>
#if NET45 || NET40
    [Serializable]
#endif
    public class DeserializableOutcome : IOutcome
    {
        public int? StatusCode { get; set; }
        public bool Success { get; set; }
        public bool Failure { get; set; }
        public List<string> Messages { get; set; }
        public Dictionary<string, object> Keys { get; set; }

        /// <returns>The message list, concatenated.</returns>
        public override string ToString()
        {
            return ToMultiLine(string.Empty);
        }

        /// <summary>
        /// Dumps the message list into a string, with a delimiter after each line. If no delimiter is specified, Outcome will make sure there is
        /// a space after each message.
        /// </summary>
        /// <param name="delimiter">A delimiter that goes after each string in the message list. Useful for implementing platform-appropriate line breaks.</param>
        /// <returns>The message list, concatenated.</returns>       
        public string ToMultiLine(string delimiter = null)
        {
            return MultiLineFormatter.ToMultiLine(delimiter, Messages);
        }
    }

    /// <summary>
    /// This class is intended for cases where you need to deserialize an Outcome using 
    /// libraries like RestSharp, ServiceStack.Text, or Json.Net.
    /// 
    /// Do not use this class to instantiate new Outcomes of your own. Use the Outcomes API instead.
    /// </summary>
#if NET45 || NET40
    [Serializable]
#endif
    public class DeserializableOutcome<TValue> : DeserializableOutcome
    {
        public TValue Value { get; set; }
    }
}
