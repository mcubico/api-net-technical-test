using ApiTechnicalTest.Data.Context;
using ApiTechnicalTest.Data.Entities;
using ApiTechnicalTest.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ArandaTechnicalTest.Domain.Repositories
{
    public class ProductRepository : IProductRepository
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

        public ProductRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        #endregion

        #region CRUD

        public async Task<ProductEntity> AddAsync(ProductEntity entity)
        {
            _logger.LogInformation("Registrando un nuevo producto");

            _context.Add(entity);
            _ = await _context.SaveChangesAsync();

            return entity;
        }

        public Task<ProductEntity> UpdateAsync(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region SEARCHES

        public async Task<IEnumerable<ProductEntity>> GetAllAsync(
            int page = 1, 
            int itemsPerPage = 10)
        {
            IQueryable<ProductEntity> query = _context.Products.AsQueryable();
            query = query.Skip(itemsPerPage * (page - 1)).Take(itemsPerPage);

            return await query.ToListAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id)
        {
            var response = await _context.Products
                .Include(product => product.Category)
                .FirstOrDefaultAsync(elm => elm.Id.Equals(id));

            return response;
        }

        public async Task<int> GetTotalRecordsAsync()
        {
            return await _context.Products.CountAsync();
        }

        public Task<IEnumerable<ProductEntity>> FilterAsync(int page, int itemsPerPage, string sortBy, bool directionAsc, string name, string description, string category)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region VALIDATIONS

        public async Task<bool> ExistsProduct(Guid id)
            => await _context.Products.AnyAsync(elm => elm.Id.Equals(id));

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
