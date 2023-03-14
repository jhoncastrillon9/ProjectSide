using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsterMapper;
using ProjectSide.Domain.InfrastructureContracts;
using ProjectSide.Infrastructure.Database.BoundedContexts;
using Company = ProjectSide.Domain.Entities.Company;
using CompanyDb = ProjectSide.Infrastructure.Database.DatabaseEntities.Company;


namespace ProjectSide.Infrastructure.Database.Repositories
{
    public class CompanyRepository: BaseRepository<CompanyDb>, ICompanyRepository
    {
        private IMapper _mapper;
        public CompanyRepository(ProjectSideContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public new async Task<IEnumerable<Company>> GetAllAsync()
        {
            var companies = await base.GetAllAsync().ConfigureAwait(false);
            return _mapper.Map<List<CompanyDb>, List<Company>>(companies.ToList());
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var company = await base.GetByIdAsync(id).ConfigureAwait(false);
            return _mapper.Map<CompanyDb, Company>(company);
        }

        public async Task<Company> InsertAsync(Company entityDomain)
        {
            var entityDb = _mapper.Map<Company, CompanyDb>(entityDomain);
            await base.InsertAsync(entityDb).ConfigureAwait(false);
            return entityDomain;
        }

        public async Task<Company> UpdateAsync(Company entityDomain)
        {
            var entityDb = _mapper.Map<Company, CompanyDb>(entityDomain);
            await base.UpdateAsync(entityDb).ConfigureAwait(false);
            return entityDomain;
        }
    }
}
