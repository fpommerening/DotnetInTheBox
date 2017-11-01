using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FP.DotnetInTheBox.MongoMessage.Data
{
    public class MessageRepository
    {
        private readonly string _connectionstring;

        public MessageRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public async Task<string> SaveMessage(string user, string content)
        {
            var db = GetMongoDatabase();
            var collection = db.GetCollection<DtoMessage>("Messages");
            var dto = new DtoMessage
            {
                Content = content,
                Timestamp = DateTime.Now,
                User = user
            };
            await collection.InsertOneAsync(dto);
            return dto.Id.ToString();
        }

        public async Task<List<DtoMessage>> GetMessages()
        {
            var db = GetMongoDatabase();
            var collection = db.GetCollection<DtoMessage>("Messages");
            var filter = new BsonDocument();
            var sort = Builders<DtoMessage>.Sort.Descending("timestamp");
            return await collection.Find(filter).Sort(sort).ToListAsync();
        }

        private IMongoDatabase GetMongoDatabase()
        {
            var client = new MongoClient(_connectionstring);
            return client.GetDatabase("PicFlowData");
        }
    }
}
