using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.Contracts
{
    public interface IEmployeeUsecase
    {
        Task<EmployeeModel> AddEmployeeAsync(EmployeeModel employee);
    }
}
