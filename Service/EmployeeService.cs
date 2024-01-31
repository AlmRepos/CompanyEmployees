using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            Company company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
            Employee Dbemployee = _repository.Employee.GetEmployee(companyId, id, trackChanges);
            if (Dbemployee is null)
                throw new EmployeeNotFoundException(id);

            EmployeeDto employee = _mapper.Map<EmployeeDto>(Dbemployee);

            return employee;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            Company company = _repository.Company.GetCompany(companyId, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(companyId);
            IEnumerable<Employee> employees = _repository.Employee.GetEmployees(companyId, trackChanges);

            IEnumerable<EmployeeDto> employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return employeeDtos;
        }
    }
}
