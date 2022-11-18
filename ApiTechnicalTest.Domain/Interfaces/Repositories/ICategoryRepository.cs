using ApiTechnicalTest.Data.Entities;

namespace ApiTechnicalTest.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        Task<bool> CategoryExistAsync(Guid id);
    }
}
