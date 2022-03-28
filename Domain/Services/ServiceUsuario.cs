using Domain.Interfaces.InterfaceServices;
using Domain.Interfaces.InterfaceUsuario;
using Entities.Entities;
using Entities.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IUsuario _IUsuario;
        public ServiceUsuario(IUsuario IUsuario)
        {
            _IUsuario = IUsuario;
        }
        public async Task<List<ApplicationUser>> ListarUsuarioSomenteParaAdministradores(string userID)
        {
            var usuario = await _IUsuario.ObterUsuarioPeloID(userID);
            if (usuario != null && usuario.Tipo == TipoUsuario.Administrador)
            {
                return await _IUsuario.List();
            }

            return new List<ApplicationUser>();
        }
    }
}
