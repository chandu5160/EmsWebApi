using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.UseCases
{
    internal class ClientUsecase : IClientUsecase
    {
        private readonly IClientRepository _clientRepository;

        public ClientUsecase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        Task<ClientModel> IClientUsecase.AddClientAsync(ClientModel client)
        {
            client.SetStatus(true);
            return _clientRepository.AddClientAsync(client);
        }

        Task IClientUsecase.DeleteClientsAsync(int id)
        {
            return _clientRepository.DeleteClientsAsync(id);
        }

        Task<List<ClientModel>> IClientUsecase.GetAllClientsAsync()
        {
            return _clientRepository.GetAllClientsAsync();
        }
    }
}
