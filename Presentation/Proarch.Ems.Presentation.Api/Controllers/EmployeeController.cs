using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Application.Contracts.Dto;
using Proarch.Ems.Core.Domain.Models;

namespace Proarch.Ems.Presentation.Api.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeUsecase _employeeUsecase;

        public EmployeeController(IEmployeeUsecase employeeUsecase)
        {
            this._employeeUsecase = employeeUsecase;
        }

        public async Task<IActionResult> PostEmployee([FromBody]EmployeeModel employee)
        {
            if(employee == null)
            {
                return BadRequest();
            }
            var newEmployee =await this._employeeUsecase.AddEmployeeAsync(employee).ConfigureAwait(false);
            return Ok(newEmployee);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]LoginDto employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            var autEmployee = await _employeeUsecase.Authenticate(employee);
            return Ok(autEmployee);

        }
    }
 }
