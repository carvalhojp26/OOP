using project.models;
using System;
using System.Collections.Generic;

namespace ManagementSystemLibrary
{
    public class ManagementSystem
    {
        private List<Client> clients = new List<Client>();
        private List<Stay> stays = new List<Stay>();

        public int AddClient(Client client)
        {
            if (client == null)
            {
                return 0;
            }

            clients.Add(client);
            return 1;
        }

        public int RemoveClient(int id)
        {
            if (id <= 0)
            {
                return 0;
            }

            var clientToRemove = clients.Find(client => client.Id == id);

            if (clientToRemove == null)
            {
                return 0;
            }

            clients.Remove(clientToRemove);
            return 1;
        }

        public List<Client> GetClients()
        {
            return clients;
        }

        public Client GetClientById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return clients.Find(client => client.Id == id);
        }

        public int AddStay(Stay stay)
        {
            if (stay == null)
            {
                return 0;
            }

            stays.Add(stay);
            return 1;
        }

        public int RemoveStay(int id)
        {
            if (id <= 0)
            {
                return 0;
            }

            var stayToRemove = stays.Find(stay => stay.Id == id);

            if (stayToRemove == null)
            {
                return 0;
            }

            stays.Remove(stayToRemove);
            return 1;
        }

        public List<Stay> GetStays()
        {
            return stays;
        }

        public Stay GetStayById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            return stays.Find(stay => stay.Id == id);
        }
    }
}