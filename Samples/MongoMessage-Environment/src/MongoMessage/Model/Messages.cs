using System.Collections.Generic;

namespace FP.DotnetInTheBox.Environment.Model
{
    public class Messages
    {
        public Messages()
        {
            Entries = new List<Message>();
        }

        public List<Message> Entries { get; }
    }
}
