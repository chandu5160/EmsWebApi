using AutoMapper;
using Proarch.Ems.Core.Application.Repositories;
using Proarch.Ems.Core.Domain.Models;
using Proarch.Ems.Infrastructure.Data.Common;
using Proarch.Ems.Infrastructure.Data.Entities;
using System.Threading.Tasks;

namespace Proarch.Ems.Infrastructure.Data.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmsDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(EmsDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        async Task<EmployeeModel> IEmployeeRepository.AddEmployeeAsync(EmployeeModel employee)
        {
            var newEmployee = this._mapper.Map<EmployeeEntity>(employee);
            this._context.Employee.Add(newEmployee);
            await this._context.SaveChangesAsync();
            return this._mapper.Map<EmployeeModel>(newEmployee);
        }
    }
}

