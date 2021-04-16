namespace my_budget.Interfaces
{
    public interface IBudgetSettings
    {
         string BudgetChanges { get; set; }

         string ConnectionString { get; set; }

         string DatabaseName { get; set; }
    }
}