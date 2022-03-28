using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceServices
{
    public interface IServiceUsuario
    {
        Task<List<ApplicationUser>> ListarUsuarioSomenteParaAdministradores(string userID);
    }
}
