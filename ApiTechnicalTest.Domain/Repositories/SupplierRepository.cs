using ApiTechnicalTest.Data.Context;
using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiTechnicalTest.Domain.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        #region ATTRIBUTES

        /// <summary>
        /// Se utiliza para indicar que ya se marco para liberar
        /// el espacio usado por la clase en memoria.
        /// </summary>
        protected bool disposed;

        private readonly ApplicationDbContext _context;

        #endregion

        #region CONSTRUCTORS

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD

        public Task<SupplierEntity> AddAsync(SupplierEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<SupplierEntity> UpdateAsync(SupplierEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<SupplierEntity> IRepository<SupplierEntity>.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SEARCHES

        public Task<SupplierEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SupplierEntity>> GetAllAsync(int page, int itemsPerPage)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region VALIDATIONS

        public async Task<bool> SupplierExistAsync(Guid id)
            => await _context.Suppliers.CountAsync(elm => elm.Id.Equals(id)) > 0;

        #endregion

        #region DISPOSE

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera los recursos no administrados que utiliza el objeto y, opcionalmente, libera los recursos administrados.
        /// </summary>
        /// <param name="disposing">
        /// true para liberar tanto los recursos administrados como los no administrados; false para liberar 
        /// únicamente los recursos no administrados.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            disposed = true;
        }

        #endregion
    }
}
