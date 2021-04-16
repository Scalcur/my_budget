using System.Threading.Tasks;
using my_budget.Models;
using System.Collections.Generic;

namespace my_budget.Interfaces
{
    public interface IBudgetManager
    {
        Task<List<BudgetModel>> GetAll();
        Task<string> Create(BudgetModel budget);

        Task<string> Update(string id, BudgetModel budgetIn);

        Task<string> Remove(string id);
    }
}