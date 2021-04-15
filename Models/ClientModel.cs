using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace my_budget.Models
{
    public class ClientModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string  Id { get; set; }

        [BsonElement("fromUserId")]
        public string FromUserId { get; set; }

        [BsonElement("clientName")]
        public string ClientName { get; set; }

        [BsonElement("budgetUpdate")]
        public decimal BudgetUpdate { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("time")]
        public string Time { get; set; }
    }
}