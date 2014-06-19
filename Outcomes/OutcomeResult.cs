using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ether.Outcomes
{
    public class OutcomeResult<T> : IOutcome<T>
    {
        public bool Success { get; protected set; }
        public List<string> Messages { get; protected set; }
        public T Value { get; set; }

        internal OutcomeResult(bool success)
        {
            Success = success;
            Messages = new List<string>();
            Value = default(T);
        }

        /// <returns>The message list, concatenated.</returns>
        public override string ToString()
        {
            return ToString(string.Empty);
        }

        /// <summary>
        /// Dumps the message list into a string, with a delimiter after each line. 
        /// </summary>
        /// <param name="delimiter">A delimiter that goes after each string in the message list. Useful for implementing platform-appropriate line breaks.</param>
        /// <returns>The message list, concatenated.</returns>
        public string ToString(string delimiter)
        {
            var Result = new StringBuilder();

            foreach (var Message in Messages)
            {
                Result.AppendFormat("{0}{1}", Message, delimiter);
            }

            return Result.ToString();
        }
    }
}
