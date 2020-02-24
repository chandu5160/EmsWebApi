using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proarch.Ems.Core.Application.Contracts;
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
        public async Task<EmployeeModel> PostEmployee([FromBody]EmployeeModel employee)
        {
            return await this._employeeUsecase.AddEmployeeAsync(employee).ConfigureAwait(false);
        }
    }
}
