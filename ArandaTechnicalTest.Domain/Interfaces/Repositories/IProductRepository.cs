using ArandaTechnicalTest.Data.Entities;

namespace ArandaTechnicalTest.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Products>
    {
        Task<int> GetTotalRecordsAsync();
        Task<bool> ExistsProduct(Guid id);
        Task<IEnumerable<Products>> GetAllAsync(int page = 1, int itemsPerPage = 10);
    }
}
