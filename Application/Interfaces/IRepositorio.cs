
namespace Application.Interfaces
{
    /// <summary>
    /// Interfaz genérica para un repositorio que define las operaciones CRUD básicas para cualquier entidad de tipo T.
    /// </summary>
    /// <typeparam name="T">El tipo de la entidad sobre la cual operará el repositorio. Debe ser una clase.</typeparam>

    public interface IRepositorio<T> where T : class
    {
        /// <summary>
        /// Obtiene una lista de todas las entidades de tipo T.
        /// </summary>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene una lista de solo lectura de todas las entidades de tipo T.</returns>
        Task<IReadOnlyList<T>> ObtenerTodos();

        /// <summary>
        /// Obtiene una entidad de tipo T por su identificador único.
        /// </summary>
        /// <param name="id">El identificador único de la entidad a obtener.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene la entidad de tipo T encontrada, o null si no se encuentra.</returns>
        Task<T?> ObtenerPorId(int id);

        /// <summary>
        /// Agrega una nueva entidad de tipo T al repositorio.
        /// </summary>
        /// <param name="entidad">La entidad a agregar.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene la entidad de tipo T agregada.</returns>
        Task<T?> Agregar(T entidad);

        /// <summary>
        /// Agrega una nueva entidad de tipo T al repositorio.
        /// </summary>
        /// <param name="entidad">La entidad a agregar.</param>
        /// <returns>Una tarea que representa la operación asincrónica. El resultado contiene la entidad de tipo T agregada.</returns>
        Task<T?> Actualizar(T entidad);

        /// <summary>
        /// Elimina una entidad existente de tipo T del repositorio.
        /// </summary>
        /// <param name="entidad">La entidad a eliminar.</param>
        /// <returns>Una tarea que representa la operación asincrónica.</returns>
        Task Eliminar(T entidad);
    }
    
}
