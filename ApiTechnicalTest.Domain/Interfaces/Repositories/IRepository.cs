namespace ApiTechnicalTest.Domain.Interfaces.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        #region CRUD

        /// <summary>
        /// Agrega un registro en la base de datos
        /// </summary>
        /// <param name="entity">Datos del producto</param>
        /// <returns>La entidad registrada</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Actualiza un registro en la base de datos
        /// </summary>
        /// <param name="entity">Datos que se desean actualizar</param>
        /// <returns>La entidad actualizada</returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        /// Elimina logicamente un registro de la base de datos
        /// </summary>
        /// <param name="id">Identificador principal del contacto</param>
        /// <returns>Datos de la entidad eliminada</returns>
        Task<T> DeleteAsync(Guid id);

        #endregion

        #region SEARCHES

        /// <summary>
        /// Busca un registro por su identificador principal
        /// </summary>
        /// <param name="id">Identificador principal</param>
        /// <returns>Datos del registro coincidente</returns>
        Task<T> GetByIdAsync(Guid id);

        /// <summary>
        /// Busca todos los registros
        /// </summary>
        /// <param name="page">Número de página con los resultados que se desea ver</param>
        /// <param name="itemsPerPage">Cantidad de resultados que se desean obtener</param>
        /// <returns>Lista de registros encontrados</returns>
        Task<IEnumerable<T>> GetAllAsync(int page, int itemsPerPage);

        #endregion
    }
}
