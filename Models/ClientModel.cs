using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace my_budget.Models
{
    public class ClientModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string  Id { get; set; }


        [BsonElement("clientName")]
        public string ClientName { get; set; }


        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}