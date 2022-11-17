using ArandaTechnicalTest.Data.Context;
using ArandaTechnicalTest.Data.Entities;
using ArandaTechnicalTest.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<Products> AddAsync(Products entity)
        {
            _logger.LogInformation("Registrando un nuevo producto");

            _context.Add(entity);
            _ = await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Products> UpdateAsync(Products entity)
        {
            _context.Update(entity);
            _ = await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Products> DeleteAsync(Guid id)
        {
            _context.Remove(new Products() { Id = id });
            _ = await _context.SaveChangesAsync();

            return await GetByIdAsync(id);
        }

        #endregion

        #region SEARCHES

        public async Task<IEnumerable<Products>> GetAllAsync(
            int page = 1, 
            int itemsPerPage = 10, 
            string sortBy = "", 
            bool directionAsc = true)
        {
            IQueryable<Products> query = _context.Products.AsQueryable();

            SetInqueryToOrderProducts(ref query, sortBy, directionAsc);

            query = query.Skip(itemsPerPage * (page - 1)).Take(itemsPerPage);

            return await query.ToListAsync();
        }

        public async Task<Products> GetByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(elm => elm.Id.Equals(id));
        }

        public async Task<int> GetTotalRecordsAsync()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<IEnumerable<Products>> FilterAsync(
            int page = 1, 
            int itemsPerPage = 10, 
            string sortBy = "", 
            bool directionAsc = true, 
            string name = "", 
            string description = "", 
            string category = "")
        {
            IQueryable<Products> query = _context.Products.AsQueryable();

            SetInqueryToFilterProducts(ref query, name, description, category);

            SetInqueryToOrderProducts(ref query, sortBy, directionAsc);

            query = query.Skip(itemsPerPage * (page - 1)).Take(itemsPerPage);

            return await query.ToListAsync();
        }

        #endregion

        #region VALIDATIONS

        public async Task<bool> ExistsProduct(Guid id)
            => await _context.Products.AnyAsync(elm => elm.Id.Equals(id));

        #endregion

        #region OTHER METHODS

        private static void SetInqueryToOrderProducts(ref IQueryable<Products> query, string sortBy, bool directionAsc)
        {
            if (string.IsNullOrEmpty(sortBy))
                return;

            if (sortBy.ToLower().Equals("name"))
                query = directionAsc
                ? query.OrderBy(elm => elm.Name)
                    : query.OrderByDescending(elm => elm.Name);
            else if (sortBy.ToLower().Equals("category"))
                query = directionAsc
                ? query.OrderBy(elm => elm.Category)
                    : query.OrderByDescending(elm => elm.Category);
        }

        private static void SetInqueryToFilterProducts(ref IQueryable<Products> query, string name = "", string description = "", string category = "")
        {
            if (!string.IsNullOrEmpty(name))
            {
                name = name.ToLower();
                query = query.Where(elm => elm.Name.ToLower().Contains(name));
            }

            if (!string.IsNullOrEmpty(description))
            {
                description = description.ToLower();
                query = query.Where(elm => elm.Description != null && elm.Description.ToLower().Contains(description));
            }

            if (!string.IsNullOrEmpty(category))
            {
                category = category.ToLower();
                query = query.Where(elm => elm.Category.ToLower().Contains(category));
            }
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
