using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            IEnumerable<Company> companies = _repository.Company.GetAllCompanies(trackChanges);

            IEnumerable<CompanyDto> companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDto;
        }

        public CompanyDto GetCompany(Guid Id, bool trackChanges)
        {
            Company company = _repository.Company.GetCompany(Id, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(Id);

            CompanyDto companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }
    }
}