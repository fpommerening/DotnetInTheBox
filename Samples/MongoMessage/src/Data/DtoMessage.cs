using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FP.DotnetInTheBox.MongoMessage.Data
{
    public class DtoMessage
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("user")]
        public string User { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
