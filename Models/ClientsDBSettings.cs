using my_budget.Interfaces;

namespace my_budget.Models
{
    public class ClientsDBSettings : IClientSettings
    {
        public string Clients { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}