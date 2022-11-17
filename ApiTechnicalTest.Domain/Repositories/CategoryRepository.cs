using ApiTechnicalTest.Data.Context;
using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;
using ArandaTechnicalTest.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace ApiTechnicalTest.Domain.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region ATTRIBUTES

        /// <summary>
        /// Se utiliza para indicar que ya se marco para liberar
        /// el espacio usado por la clase en memoria.
        /// </summary>
        protected bool disposed;

        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductRepository> _logger;

        #endregion

        #region CONSTRUCTORS

        public CategoryRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        #endregion

        #region CRUD

        public async Task<CategoryEntity> AddAsync(CategoryEntity entity)
        {
            _logger.LogInformation("Registrando un nuevo producto");

            _context.Add(entity);
            _ = await _context.SaveChangesAsync();

            return entity;
        }

        public Task<CategoryEntity> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryEntity> UpdateAsync(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SEARCHES
        
        public Task<IEnumerable<CategoryEntity>> GetAllAsync(int page, int itemsPerPage, string sortBy, bool directionAsc)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryEntity> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        } 

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
