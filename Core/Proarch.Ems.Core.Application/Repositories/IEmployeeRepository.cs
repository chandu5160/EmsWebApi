using Proarch.Ems.Core.Domain.Models;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel> AddEmployeeAsync(EmployeeModel employee);
    }
}
