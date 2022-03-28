using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Infrastructure.Configuration;
using ApplicationApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Web_ECommerce.Controllers
{

    [Authorize]
    [LogActionFilter]
    public class LogSistemasController : BaseController
    {
        public LogSistemasController(UserManager<ApplicationUser> userManager, ILogger<ProdutosController> logger, InterfaceLogSistemaApp InterfaceLogSistemaApp)
                   : base(logger, userManager, InterfaceLogSistemaApp)
        {

        }

        // GET: LogSistemas
        public async Task<IActionResult> Index()
        {
            if (!await UsuarioAdministrador())
                return RedirectToAction("Index", "Home");

            return View(await _InterfaceLogSistemaApp.List());
        }

        // GET: LogSistemas/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (!await UsuarioAdministrador())
                return RedirectToAction("Index", "Home");

            if (id == null)
            {
                return NotFound();
            }

            var logSistema = await _InterfaceLogSistemaApp.GetEntityById((int)id);
            if (logSistema == null)
            {
                return NotFound();
            }

            return View(logSistema);
        }


    }
}
