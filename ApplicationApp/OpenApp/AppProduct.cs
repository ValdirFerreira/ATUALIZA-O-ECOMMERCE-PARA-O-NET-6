using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : InterfaceProductApp
    {
        IProduct _IProduct;
        IServiceProduct _IServiceProduct;
        public AppProduct(IProduct IProduct, IServiceProduct IServiceProduct)
        {
            _IProduct = IProduct;
            _IServiceProduct = IServiceProduct;
        }


        public async Task<List<Produto>> ListarProdutosCarrinhoUsuario(string userId)
        {
            return await _IProduct.ListarProdutosCarrinhoUsuario(userId);
        }

        public async Task<Produto> ObterProdutoCarrinho(int idProdutoCarrinho)
        {
            return await _IProduct.ObterProdutoCarrinho(idProdutoCarrinho);
        }



        public async Task AddProduct(Produto produto)
        {
            await _IServiceProduct.AddProduct(produto);
        }
        public async Task UpdateProduct(Produto produto)
        {
            await _IServiceProduct.UpdateProduct(produto);
        }

        public async Task<List<Produto>> ListarProdutosUsuario(string userId)
        {
            return await _IProduct.ListarProdutosUsuario(userId);
        }

        public async Task<List<Produto>> ListarProdutosVendidos(string userId, string filtro)
        {
            return await _IProduct.ListarProdutosVendidos(userId, filtro);
        }


        public async Task Add(Produto Objeto)
        {
            await _IProduct.Add(Objeto);
        }
        public async Task Delete(Produto Objeto)
        {
            await _IProduct.Delete(Objeto);
        }
        public async Task<Produto> GetEntityById(int Id)
        {
            return await _IProduct.GetEntityById(Id);
        }

        public async Task<List<Produto>> List()
        {
            return await _IProduct.List();
        }

        public async Task Update(Produto Objeto)
        {
            await _IProduct.Update(Objeto);
        }

        public async Task<List<Produto>> ListarProdutosComEstoque(string descricao)
        {
            return await _IServiceProduct.ListarProdutosComEstoque(descricao);
        }

       
    }
}
