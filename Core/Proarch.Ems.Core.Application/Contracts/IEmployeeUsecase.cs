using Proarch.Ems.Core.Domain.Models;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Contracts
{
    public interface IEmployeeUsecase
    {
        Task<EmployeeModel> AddEmployeeAsync(EmployeeModel employee);
    }
}
