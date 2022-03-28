using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
   public interface InterfaceMontaMenu
    {
        Task<List<MenuSite>> MontaMenuPorPerfil(string userID);
    }
}
