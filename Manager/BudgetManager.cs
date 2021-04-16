using my_budget.Models;
using my_budget.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_budget.Manager
{
    public class BudgetManager : IBudgetManager
    {
        private readonly IMongoCollection<BudgetModel> _budget;

        public BudgetManager(IAppOption settings)
        {
            
            var budget = new MongoClient(settings.BudgetSettings.ConnectionString);
            
            var database = budget.GetDatabase(settings.BudgetSettings.DatabaseName);

            _budget = database.GetCollection<BudgetModel>(settings.BudgetSettings.BudgetChanges);
        }

        public async Task<List<BudgetModel>> GetAll()
        {
            var getList = _budget.Find(budget => true).ToList();

            return getList;
        }

        public BudgetModel GetOne(string id) =>
            _budget.Find<BudgetModel>(budget => budget.Id == id).FirstOrDefault();

        public async Task<string> Create(BudgetModel budget)
        {
            _budget.InsertOne(budget);
            return "Note has been added";
        }

        public async Task<string> Update(string id, BudgetModel budgetIn)
        {
            _budget.ReplaceOne(budget => budget.Id == id, budgetIn);
            return budgetIn.ToString();

        }

        public async Task<string> Remove(string id)
        { 
            var budget = _budget.Find<BudgetModel>(budget => budget.Id == id).FirstOrDefault();

            if (budget == null)
            {
                return "Note not found";
            }

            _budget.DeleteOne(budget => budget.Id == id);
            return "Note has been deleted";
        }
    }
}