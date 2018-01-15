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

        public void CreateClient(Client cli)
        {

            repo.CreateClient(cli);

        }

        public void CreateRecord(Consult con)
        {

            repo.CreateRecord(con);

        }

        public void DeleteClient(Client con)
        {

            repo.DeleteClient(con);

        }


        public List<Consult> GetRecord(Client cli, string doctorUserName)
        {

           var data = repo.GetRecord(cli, doctorUserName);

            return data;
        }

        public Client GetClientById(Client cli)
        {

            var data = repo.GetClientById(cli);

            return data;

        }

        public void SaveClient(Client con)
        {

            repo.SaveClient(con);


        }



    }



}
