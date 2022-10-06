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
        public async Task<IActionResult> PostClient([FromBody]ClientModel client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            //Client
            var newclient = await this._clientUsecase.AddClientAsync(client).ConfigureAwait(false);
            return Created("created new role client", newclient);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var allClients = await this._clientUsecase.GetAllClientsAsync().ConfigureAwait(false);
            if (allClients == null)
            {
                return NotFound();
            }

            return Ok(allClients);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await this._clientUsecase.DeleteClientsAsync(id).ConfigureAwait(false);

            return this.Ok();
        }
    }
}
