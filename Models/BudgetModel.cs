using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace my_budget.Models
{
    public class BudgetModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string  Id { get; set; }


        [BsonElement("fromClientId")]
        public string FromClientId { get; set; }


        [BsonElement("budgetUpdate")]
        public decimal BudgetUpdate { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("time")]
        public string Time { get; set; }
    }
}