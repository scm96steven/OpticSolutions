using OpticSolutions.Repositories;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Services
{
    public class ClientService
    {
       public ClientRepository repo = new ClientRepository();


        public List<Client> SearchClients(Client cli)
        {
            var data = repo.SearchClients(cli);

            return data;
        }
}



}
