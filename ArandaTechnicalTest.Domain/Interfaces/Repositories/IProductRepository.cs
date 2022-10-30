using ArandaTechnicalTest.Data.Entities;

namespace ArandaTechnicalTest.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Products>
    {
        Task<int> GetTotalRecordsAsync();
        Task<bool> ExistsProduct(Guid id);
    }
}
