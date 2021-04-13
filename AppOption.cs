using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Configuration;
using my_budget.Interfaces;
using my_budget.Models;

namespace my_budget
{
    public class AppOption : IAppOption
    {
        public IClientSettings ClientSettings { get; set; }
        private readonly IConfiguration _configuration;
        
        public AppOption(IConfiguration configuration)
        {
            _configuration = configuration;
            ClientSettings = _configuration.GetSection("BudgetDatabaseSettings").Get<ClientsDBSettings>();
        }
    }
}