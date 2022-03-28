using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_ECommerce.Controllers
{
    public class MontaMenu : BaseController
    {
        private readonly InterfaceMontaMenu _InterfaceMontaMenu;
        public MontaMenu(UserManager<ApplicationUser> userManager, ILogger<ProdutosController> logger, InterfaceLogSistemaApp InterfaceLogSistemaApp, InterfaceMontaMenu InterfaceMontaMenu)
                   : base(logger, userManager, InterfaceLogSistemaApp)
        {
            _InterfaceMontaMenu = InterfaceMontaMenu;
        }

        [AllowAnonymous]
        [HttpGet("/api/ListarMenu")]
        public async Task<IActionResult> ListarMenu()
        {
            var listaMenu = new List<MenuSite>();

            var usuario = await RetornarIdUsuarioLogado();

            listaMenu = await _InterfaceMontaMenu.MontaMenuPorPerfil(usuario);

            return Json(new { listaMenu });
        }

    }
}
