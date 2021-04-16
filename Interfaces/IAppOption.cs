namespace my_budget.Interfaces
{
    public interface IAppOption
    {
        IClientSettings ClientSettings { get; set; }

        IBudgetSettings BudgetSettings { get; set; }
    }
}