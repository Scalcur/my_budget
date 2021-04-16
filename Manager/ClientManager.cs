using my_budget.Models;
using my_budget.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace my_budget.Manager
{
    public class ClientManager : IClientManager
    {
        private readonly IMongoCollection<ClientModel> _clients;

        public ClientManager(IAppOption settings)
        {
            
            var client = new MongoClient(settings.ClientSettings.ConnectionString);
            
            var database = client.GetDatabase(settings.ClientSettings.DatabaseName);

            _clients = database.GetCollection<ClientModel>(settings.ClientSettings.Clients);
        }

        public async Task<List<ClientModel>> GetAll()
        {
            var getList = _clients.Find(client => true).ToList();

            return getList;
        }

        public ClientModel GetOne(string id) =>
            _clients.Find<ClientModel>(client => client.Id == id).FirstOrDefault();

        public async Task<string> Create(ClientModel client)
        {
            _clients.InsertOne(client);
            return "Client has been added";
        }

        public async Task<string> Update(string id, ClientModel clientIn)
        {
            _clients.ReplaceOne(client => client.Id == id, clientIn);
            return clientIn.ToString();

        }

        /*public async Task<string> Remove(ClientModel clientIn)
        {
            _clients.DeleteOne(client => client.Id == clientIn.Id);
            return "Note has been deleted";
        }*/

        public async Task<string> Remove(string id)
        { 
            var client = _clients.Find<ClientModel>(client => client.Id == id).FirstOrDefault();

            if (client == null)
            {
                return "Client not found";
            }

            _clients.DeleteOne(client => client.Id == id);
            return "Client has been deleted";
        }
    }
}