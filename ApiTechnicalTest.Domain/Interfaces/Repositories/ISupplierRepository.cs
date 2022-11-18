using ApiTechnicalTest.Data.Entities;

namespace ApiTechnicalTest.Domain.Interfaces.Repositories
{
    public interface ISupplierRepository : IRepository<SupplierEntity>
    {
        Task<bool> SupplierExistAsync(Guid id);
    }
}
