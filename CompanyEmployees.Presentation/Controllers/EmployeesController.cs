using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("/api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId,bool trackChanges)
        {
            IEnumerable<EmployeeDto> employeeDtos = _service.EmployeeService.GetEmployees(companyId, false);

            return Ok(employeeDtos);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeForCompany(Guid companyId,Guid id,bool trackChanges)
        {
            EmployeeDto employee = _service.EmployeeService.GetEmployee(companyId, id, false);

            return Ok(employee);
        }





    }
}
