using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace my_budget.Models
{
    public class ClientModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("ClientName")]
        public string ClientName { get; set; }

        public decimal BudgetUpdate { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}