using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace my_budget.Models
{
    public class UserModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userName")]
        public string UserName { get; set; }

        [BsonElement("userEmail")]
        public string UserEmail { get; set; }

        [BsonElement("userPassword")]
        public string UserPassword { get; set; }
    }
}