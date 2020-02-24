using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using Proarch.Ems.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Repositories
{
    internal class ClientRepository : IClientRepository
    {
        private readonly EmsDbContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(EmsDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

     async   Task<ClientModel> IClientRepository.AddClientAsync(ClientModel client)
        {
            var clientEntity = _mapper.Map<ClientEntity>(client);
            this._context.Client.Add(clientEntity);
            await this._context.SaveChangesAsync().ConfigureAwait(false);
            return this._mapper.Map<ClientModel>(clientEntity);
        }

       async Task IClientRepository.DeleteClientsAsync(int id)
        {

            var existingClientEntity = await this._context
                                   .Client
                                   .SingleOrDefaultAsync(x => x.Id == id)
                                   .ConfigureAwait(false);
            if (existingClientEntity != null)
            {
                this._context.Client.Remove(existingClientEntity);
                await this._context.SaveChangesAsync().ConfigureAwait(false);
            }
        }

       async Task<List<ClientModel>> IClientRepository.GetAllClientsAsync()
        {
            var clientList = await this._context.Client.Where(x => x.Status == true).ToListAsync();
            return this._mapper.Map<List<ClientModel>>(clientList);
        }
    }
}
