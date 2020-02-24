using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Contracts
{
    public interface IClientUsecase
    {
        Task<ClientModel> AddClientAsync(ClientModel client);
       
        Task DeleteClientsAsync(int id);
        Task<List<ClientModel>> GetAllClientsAsync();
    }
}
