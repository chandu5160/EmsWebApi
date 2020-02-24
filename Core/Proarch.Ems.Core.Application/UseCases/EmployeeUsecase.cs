using Proarch.Ems.Core.Application.Contracts;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proarch.Ems.Core.Application.UseCases
{
    internal class EmployeeUsecase : IEmployeeUsecase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeUsecase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        Task<EmployeeModel> IEmployeeUsecase.AddEmployeeAsync(EmployeeModel employee)
        {
            return _employeeRepository.AddEmployeeAsync(employee);
        }
    }
}
