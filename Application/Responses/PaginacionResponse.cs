

namespace Application.Responses
{
    /// <summary>
    /// Clase genérica que extiende <see cref="ApiResponse{T}"/> para incluir información de paginación 
    /// junto con los datos de respuesta.
    /// </summary>
    /// <typeparam name="T">El tipo de dato que representa el resultado de la operación.</typeparam>
    public class PaginacionResponse<T> : ApiResponse<T>
    {
        /// <summary>
        /// Número de la página actual.
        /// </summary>
        public int NumeroPagina { get; set; }

        /// <summary>
        /// Tamaño de la página, es decir, la cantidad de elementos por página.
        /// </summary>
        public int TamanioPagina { get; set; }

        /// <summary>
        /// Constructor para inicializar una respuesta de paginación con los datos proporcionados.
        /// </summary>
        /// <param name="resultado">El resultado de la operación.</param>
        /// <param name="numeroPagina">El número de la página actual.</param>
        /// <param name="tamanioPagina">El tamaño de la página (cantidad de elementos por página).</param>
        public PaginacionResponse(T resultado, int numeroPagina, int tamanioPagina)
        {
            NumeroPagina = numeroPagina;
            TamanioPagina = tamanioPagina;
            Resultado = resultado;
            Mensaje = "";
            Exitoso = true;
            Errores = new List<string>();
        }
    }
}
