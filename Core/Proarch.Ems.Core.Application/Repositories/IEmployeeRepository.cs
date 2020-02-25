using Proarch.Ems.Core.Application.Contracts.Dto;
using Proarch.Ems.Core.Domain.Models;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel> AddEmployeeAsync(EmployeeModel employee);
        Task<EmployeeModel> Authenticate(LoginDto employee);
    }
}
