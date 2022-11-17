using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;

namespace ApiTechnicalTest.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<int> GetTotalRecordsAsync();
        Task<IEnumerable<ProductEntity>> FilterAsync(int page, int itemsPerPage, string sortBy, bool directionAsc, string name, string description, string category);
        Task<bool> ExistsProduct(Guid id);
    }
}
