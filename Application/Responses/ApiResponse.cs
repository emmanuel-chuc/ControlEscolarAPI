using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    /// <summary>
    /// Clase genérica utilizada para encapsular las respuestas de una API, 
    /// proporcionando información sobre el estado de la operación, un mensaje, 
    /// errores opcionales y el resultado.
    /// </summary>
    /// <typeparam name="T">El tipo de dato que representa el resultado de la operación.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Indica si la operación fue exitosa.
        /// </summary>
        /// <value>
        /// true si la operación fue exitosa; false si falló.
        /// </value>
        public bool Exitoso { get; set; }

        /// <summary>
        /// Mensaje asociado a la operación, ya sea de éxito o error.
        /// </summary>
        public string Mensaje { get; set; } = null!;

        /// <summary>
        /// Lista de errores asociados a la operación, en caso de fallo.
        /// </summary>
        public List<string> Errores { get; set; } = new List<string>();

        /// <summary>
        /// Resultado devuelto como parte de la respuesta. 
        /// Puede ser null si la operación no tiene un resultado o falló.
        /// </summary>
        public T? Resultado { get; set; }

        /// <summary>
        /// Constructor por defecto. Inicializa una instancia vacía de la clase.
        /// </summary>
        public ApiResponse() { }

        /// <summary>
        /// Constructor para crear una respuesta exitosa con un resultado y un mensaje opcional.
        /// </summary>
        /// <param name="resultado">El resultado de la operación.</param>
        /// <param name="mensaje">Un mensaje opcional que describe la operación.</param>
        public ApiResponse(T resultado, string mensaje = "")
        {
            Exitoso = true;
            Mensaje = mensaje;
            Resultado = resultado;
        }

        /// <summary>
        /// Constructor para crear una respuesta de error con un mensaje.
        /// </summary>
        /// <param name="mensaje">El mensaje que describe el error.</param>
        public ApiResponse(string mensaje)
        {
            Exitoso = false;
            Mensaje = mensaje;
        }
    }
}
