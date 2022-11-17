using ArandaTechnicalTest.Data.Entities;

namespace ArandaTechnicalTest.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Products>
    {
        Task<int> GetTotalRecordsAsync();
        Task<IEnumerable<Products>> FilterAsync(int page, int itemsPerPage, string sortBy, bool directionAsc, string name, string description, string category);
        Task<bool> ExistsProduct(Guid id);
    }
}
