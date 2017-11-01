using System.Collections.Generic;

namespace FP.DotnetInTheBox.MongoMessage.Modell
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
