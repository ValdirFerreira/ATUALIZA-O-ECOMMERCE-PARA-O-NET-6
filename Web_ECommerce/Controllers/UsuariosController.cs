using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Web_ECommerce.Controllers
{
    [Authorize]
    [LogActionFilter]
    public class UsuariosController : BaseController
    {
        private readonly InterfaceUsuarioApp _InterfaceUsuarioApp;
        public UsuariosController(UserManager<ApplicationUser> userManager, ILogger<ProdutosController> logger,
             IWebHostEnvironment environment, InterfaceLogSistemaApp InterfaceLogSistemaApp,
            InterfaceUsuarioApp InterfaceUsuarioApp) : base(logger, userManager, InterfaceLogSistemaApp)
        {
            _InterfaceUsuarioApp = InterfaceUsuarioApp;
        }

        public async Task<IActionResult> ListarUsuarios()
        {
            return View(await _InterfaceUsuarioApp.ListarUsuarioSomenteParaAdministradores(await RetornarIdUsuarioLogado()));
        }

        // GET
        public async Task<IActionResult> Edit(string id)
        {
            var tipoUsuarios = new List<SelectListItem>();

            tipoUsuarios.Add(new SelectListItem { Text = Enum.GetName(typeof(TipoUsuario), TipoUsuario.Comum), Value = Convert.ToInt32(TipoUsuario.Comum).ToString() });
            tipoUsuarios.Add(new SelectListItem { Text = Enum.GetName(typeof(TipoUsuario), TipoUsuario.Administrador), Value = Convert.ToInt32(TipoUsuario.Administrador).ToString() });
            ViewBag.TipoUsuarios = tipoUsuarios;

            return View(await _InterfaceUsuarioApp.ObterUsuarioPeloID(id));

        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApplicationUser usuario)
        {
            try
            {
                await _InterfaceUsuarioApp.AtualizarTipoUsuario(usuario.Id, (TipoUsuario)usuario.Tipo);

                await LogEcommerce(EnumTipoLog.Informativo, usuario);

                return RedirectToAction(nameof(ListarUsuarios));
            }
            catch (Exception erro)
            {
                await LogEcommerce(EnumTipoLog.Erro, erro);

                return View("Edit", usuario);
            }
        }

    }
}
