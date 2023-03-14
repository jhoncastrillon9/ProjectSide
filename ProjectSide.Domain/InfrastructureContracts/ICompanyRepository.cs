using ProjectSide.Domain.Entities;


namespace ProjectSide.Domain.InfrastructureContracts
{
    public interface ICompanyRepository
    {
        public Task<IEnumerable<Company>> GetAllAsync();
        public Task<Company> GetByIdAsync(int id);
        public Task<Company> InsertAsync(Company entity);
        public Task<Company> UpdateAsync(Company entity);

    }
}
