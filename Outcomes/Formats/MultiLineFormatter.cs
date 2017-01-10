using System.Collections.Generic;
using System.Text;

namespace Ether.Outcomes.Formats
{
    public class MultiLineFormatter
    {
        /// <summary>
        /// Dumps the message list into a string, with a delimiter after each line. 
        /// </summary>
        public static string ToMultiLine(string delimiter, List<string> messages)
        {
            var result = new StringBuilder();

            foreach (var message in messages)
            {
                if (delimiter == null)
                    HandleNullDelimiter(result, message);
                else
                    result.AppendFormat("{0}{1}", message, delimiter);
            }

            return result.ToString();
        }

        /// <summary>
        /// If the delimiter is null, we make sure there is at least one space between messages.
        /// </summary>
        private static void HandleNullDelimiter(StringBuilder builder, string nextMessage)
        {
            //If builder is empty, there's nothing to do.
            if (builder.Length == 0)
            {
                builder.Append(nextMessage);
                return;
            }

            //If builder ends with a space or the message starts with a space, there is already a space,
            //so we don't have to do anything.
            if (builder[builder.Length - 1] == ' ' || nextMessage.StartsWith(" "))
            {
                builder.Append(nextMessage);
                return;
            }

            //Otherwise, there is no space, and we need to add one before the message.
            builder.Append(" ");
            builder.Append(nextMessage);
        }
    }
}
