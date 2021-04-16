using my_budget.Interfaces;

namespace my_budget.Models
{
    public class BudgetDBSettings : IBudgetSettings
    {
        public string BudgetChanges { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}