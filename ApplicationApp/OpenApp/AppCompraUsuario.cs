using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceCompraUsuario;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppCompraUsuario : InterfaceCompraUsuarioApp
    {
        private readonly ICompraUsuario _ICompraUsuario;

        private readonly IServiceCompraUsuario _IServiceCompraUsuario;

        public AppCompraUsuario(ICompraUsuario ICompraUsuario, IServiceCompraUsuario IServiceCompraUsuario)
        {
            _ICompraUsuario = ICompraUsuario;
            _IServiceCompraUsuario = IServiceCompraUsuario;
        }


        public async Task<CompraUsuario> CarrinhoCompras(string userId)
        {
            return await _IServiceCompraUsuario.CarrinhoCompras(userId);
        }

        public async Task<CompraUsuario> ProdutosComprados(string userId, int? idCompra = null)
        {
            return await _IServiceCompraUsuario.ProdutosComprados(userId, idCompra);
        }

        public async Task<bool> ConfirmaCompraCarrinhoUsuario(string userId)
        {
            return await _ICompraUsuario.ConfirmaCompraCarrinhoUsuario(userId);
        }




        public async Task<int> QuantidadeProdutoCarrinhoUsuario(string userId)
        {
            return await _ICompraUsuario.QuantidadeProdutoCarrinhoUsuario(userId);
        }


        public async Task Add(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Add(Objeto);
        }

        public async Task Delete(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Delete(Objeto);
        }

        public async Task<CompraUsuario> GetEntityById(int Id)
        {
            return await _ICompraUsuario.GetEntityById(Id);
        }

        public async Task<List<CompraUsuario>> List()
        {
            return await _ICompraUsuario.List();
        }



        public async Task Update(CompraUsuario Objeto)
        {
            await _ICompraUsuario.Update(Objeto);
        }

        public async Task<List<CompraUsuario>> MinhasCompras(string userId)
        {
            return await _IServiceCompraUsuario.MinhasCompras(userId);
        }

        public async Task AdicionaProdutoCarrinho(string userId, CompraUsuario compraUsuario)
        {
            await _IServiceCompraUsuario.AdicionaProdutoCarrinho(userId, compraUsuario);
        }
    }
}
