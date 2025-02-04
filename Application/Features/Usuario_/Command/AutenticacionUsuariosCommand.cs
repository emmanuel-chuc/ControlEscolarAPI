using Application.Exceptions;
using Application.Interfaces;
using Application.Responses;
using Domain.Entities;
using Domain.Models;
using Domain.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuario_.Command
{
    public class AutenticacionUsuariosCommand : IRequest<ApiResponse<UsuarioModel>>
    {
        public string Nombre { get; set; } = null!;
        public string Password { get; set; } = null!;
    }


    /// <summary>
    /// Controlador del comando de autenticación de usuarios.
    /// </summary>
    public class AuthenticationUsuarioCommandHandler : IRequestHandler<AutenticacionUsuariosCommand, ApiResponse<UsuarioModel>>
    {
        private readonly IRepositorioUsuario _repositorio;
        private readonly JwtSettings _jwtSettings;

        /// <summary>
        /// Constructor de la clase AuthenticationUsuarioCommandHandler.
        /// </summary>
        /// <param name="repositorio">El repositorio de usuarios.</param>
        /// <param name="jwtSettings">Configuraciones de JWT.</param>
        public AuthenticationUsuarioCommandHandler(IRepositorioUsuario repositorio, IOptions<JwtSettings> jwtSettings)
        {
            _repositorio = repositorio;
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Maneja el comando de autenticación de usuarios.
        /// </summary>
        /// <param name="request">El comando de autenticación que contiene el nombre de usuario y contraseña.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Una respuesta de API que contiene el modelo de usuario con el token de acceso.</returns>
        /// <exception cref="ApiException">Se lanza si las credenciales son incorrectas o el usuario no existe.</exception>
        public async Task<ApiResponse<UsuarioModel>> Handle(AutenticacionUsuariosCommand request, CancellationToken cancellationToken)
        {
            // Obtener el usuario por nombre y contraseña
            Usuario? usuario = await _repositorio.ObtenerUsuarioPorNombreYPassword(request.Nombre, request.Password);

            // Validar si el usuario es nulo
            if (usuario == null)
            {
                throw new ApiException("Credenciales incorrectas o Usuario no existente");
            }

            // Generar los claims del token JWT
            var claims = new List<Claim>
        {
            new Claim("username", usuario.Nombre),
            new Claim("role", usuario.Rol),
        };

            // Crear el token JWT
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(4),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                    SecurityAlgorithms.HmacSha256
                )
            );

            // Convertir el token a string
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // Crear el modelo de usuario autenticado
            UsuarioModel usuarioAuth = new UsuarioModel
            {
                AccesoToken = tokenString,
                UsuarioId = usuario.UsuarioId,
                Rol = usuario.Rol,
                Nombre = usuario.Nombre,
            };

            // Retornar la respuesta de API con los datos del usuario autenticado
            return new ApiResponse<UsuarioModel>(usuarioAuth, "Login Completado");
        }
    }
}