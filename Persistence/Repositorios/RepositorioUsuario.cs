using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositorios
{
    public class RepositorioUsuario : Repositorio<Usuario>, IRepositorioUsuario
    {

        public RepositorioUsuario(ControlEscolarDbContext controlEscolarDBContext) : base(controlEscolarDBContext)
        {
        }

        public async Task<Usuario?> ObtenerUsuarioPorNombreYPassword(string Nombre, string Password)
        {
            return await _controlEscolarDBContext.Set<Usuario>()
                .Where(usuario => usuario.Nombre == Nombre && usuario.Password == Password)
                .FirstOrDefaultAsync();
        }
    }
}
