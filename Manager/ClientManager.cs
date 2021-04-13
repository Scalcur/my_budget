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

        public ClientManager(IClientSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _clients = database.GetCollection<ClientModel>(settings.Clients);
        }

        public async Task<List<ClientModel>> GetAll()
        {
            var getList = _clients.Find(client => true).ToList();

            return getList;
        }

        public ClientModel GetOne(int id) =>
            _clients.Find<ClientModel>(client => client.Id == id).FirstOrDefault();

        public ClientModel Create(ClientModel client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public void Update(int id, ClientModel clientIn) =>
            _clients.ReplaceOne(client => client.Id == id, clientIn);

        public void Remove(ClientModel clientIn) =>
            _clients.DeleteOne(client => client.Id == clientIn.Id);

        public void Remove(int id) => 
            _clients.DeleteOne(client => client.Id == id);
    }
}