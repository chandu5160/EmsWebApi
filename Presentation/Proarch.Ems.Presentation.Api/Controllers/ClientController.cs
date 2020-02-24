using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Domain.Models;

namespace Proarch.Ems.Presentation.Api.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientUsecase _clientUsecase;

        public ClientController(IClientUsecase clientUsecase)
        {
            this._clientUsecase = clientUsecase;
        }
        [HttpPost]
        public async Task<ClientModel> PostClient([FromBody]ClientModel client)
        {
            return await this._clientUsecase.AddClientAsync(client).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<List<ClientModel>> GetAllClients()
        {
            return await this._clientUsecase.GetAllClientsAsync().ConfigureAwait(false);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await this._clientUsecase.DeleteClientsAsync(id).ConfigureAwait(false);

            return this.Ok();
        }
    }
}
