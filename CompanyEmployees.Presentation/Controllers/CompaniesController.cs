using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service) => _service = service;
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _service.CompanyService.GetAllCompanies(trackChanges: false);

            return Ok(companies);
        }


        [HttpGet("{Id:guid}")]
        public IActionResult GetCompany(Guid Id)
        {
            CompanyDto companyDto = _service.CompanyService.GetCompany(Id, false);

            return Ok(companyDto);
        }
    }
}
