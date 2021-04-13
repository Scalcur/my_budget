namespace my_budget.Interfaces
{
    public interface IClientSettings
    {
        string Clients { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; } 
    }
}