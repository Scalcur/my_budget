using System.Threading.Tasks;
using my_budget.Models;
using System.Collections.Generic;

namespace my_budget.Interfaces
{
    public interface IClientManager
    {
        Task<List<ClientModel>> GetAll();
        Task<string> Create(ClientModel client);

        Task<string> Update(string id, ClientModel clientIn);

        Task<string> Remove(string id);

    }
}