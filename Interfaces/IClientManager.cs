using System.Threading.Tasks;
using my_budget.Models;
using System.Collections.Generic;

namespace my_budget.Interfaces
{
    public interface IClientManager
    {
        Task<List<ClientModel>> GetAll();
    }
}