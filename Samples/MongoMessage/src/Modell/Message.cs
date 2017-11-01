using System;

namespace FP.DotnetInTheBox.MongoMessage.Modell
{
    public class Message
    {
        public string UserName { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
