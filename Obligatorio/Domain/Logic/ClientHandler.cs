﻿using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Data;
using Domain.Interface;
using Domain.Exceptions;

namespace Domain.Logic
{
    public class ClientHandler : IUserHandler<Client>
    {
        private DataStorage storage;
        public ClientHandler()
        {
            this.storage = DataStorage.GetStorageInstance();
        }

        public Client Get(Client client)
        {
            NotExist(client);
            return this.storage.GetClient(client);
        }
        public void Add(Client client)
        {
            Validate(client);
            Exist(client);
            this.storage.SaveClient(client);
        }
        public void Validate(Client client)
        {
            DataValidation.ValidateUsername(client.Username);
            DataValidation.ValidatePassword(client.Password);
            DataValidation.ValidateNameAndSurname(client.Name, client.Surname);
            //DataValidation.ValidateID(client.Id);
            DataValidation.ValidatePhone(client.Phone);
            DataValidation.ValidateAddress(client.Address);
        }
        public void Delete(Client client)
        {
            NotExist(client);
            this.storage.DeleteClient(client);
        }
        public void Modify(Client clientToModify, Client modifiedClient)
        {
            NotExist(clientToModify);
            Validate(modifiedClient);
            if (!clientToModify.Equals(modifiedClient))
            {
                Exist(modifiedClient);
            }
            this.storage.ModifyClient(clientToModify, modifiedClient);
        }

        public void Exist(Client client)
        {
            if (this.storage.Clients.Contains(client))
            {
                throw new ExceptionController(ExceptionMessage.USER_ALREADY_EXSIST);
            }
        }
        public void NotExist(Client client)
        {
            if (!this.storage.Clients.Contains(client))
            {
                throw new ExceptionController(ExceptionMessage.USER_NOT_EXIST);
            }
        }
        public List<Client> GetList()
        {
            List<Client> clientList = storage.Clients;
            IsNotEmpty(clientList);
            return clientList;
        }
        private void IsNotEmpty(List<Client> clientList)
        {
            if (!clientList.Any())
            {
                throw new ExceptionController(ExceptionMessage.EMPTY_CLIENTS_LIST);
            }
        }
    }
}
