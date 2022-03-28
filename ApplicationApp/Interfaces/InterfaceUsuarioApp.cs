using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceUsuarioApp : InterfaceGenericaApp<ApplicationUser>
    {
        Task<ApplicationUser> ObterUsuarioPeloID(string userID);
        Task AtualizarTipoUsuario(string userID, TipoUsuario tipoUsuario);
        Task<List<ApplicationUser>> ListarUsuarioSomenteParaAdministradores(string userID);
    }
}
