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
            //var connectionToCluster = new MongoUrlBuilder(settings.ClientSettings.ConnectionString);
            var client = new MongoClient(settings.ClientSettings.ConnectionString);
            
            var database = client.GetDatabase(settings.ClientSettings.DatabaseName);

            _clients = database.GetCollection<ClientModel>(settings.ClientSettings.Clients);
            var d = 1;
        }

        public async Task<List<ClientModel>> GetAll()
        {
            var getList = _clients.Find(client => true).ToList();

            return getList;
        }

        public ClientModel GetOne(string id) =>
            _clients.Find<ClientModel>(client => client.Id == id).FirstOrDefault();

        public ClientModel Create(ClientModel client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public void Update(string id, ClientModel clientIn) =>
            _clients.ReplaceOne(client => client.Id == id, clientIn);

        public void Remove(ClientModel clientIn) =>
            _clients.DeleteOne(client => client.Id == clientIn.Id);

        public void Remove(string id) => 
            _clients.DeleteOne(client => client.Id == id);
    }
}