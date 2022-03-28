using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSite.Controllers
{
    [Authorize]
    public class ProdutoAPIController : Controller
    {

        public readonly InterfaceProductApp _InterfaceProductApp;
        public readonly InterfaceCompraUsuarioApp _InterfaceCompraUsuarioApp;

        public ProdutoAPIController(InterfaceProductApp InterfaceProductApp, InterfaceCompraUsuarioApp InterfaceCompraUsuarioApp)
        {
            _InterfaceProductApp = InterfaceProductApp;
            _InterfaceCompraUsuarioApp = InterfaceCompraUsuarioApp;
        }


        [HttpGet("/api/ListaProdutos")]
        public async Task<JsonResult> ListaProdutos(string descricao)
        {
            return Json(await _InterfaceProductApp.ListarProdutosComEstoque(descricao));
        }

    }
}
