using Domain.Interfaces.InterfaceProduct;
using Domain.Interfaces.InterfaceServices;
using Domain.Services;
using Entities.Entities;
using Infrastructure.Repository.Repositories;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestEcommerceDDD
{
    [TestClass]
    public class UnitTestEcomerce
    {
        [TestMethod]
        public async Task AddProductComSucesso()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _IServiceProduct = new ServiceProduct(_IProduct);
                var produto = new Produto
                {
                    Descricao = string.Concat("Descrição Test TDD", DateTime.Now.ToString()),
                    QtdEstoque = 10,
                    Nome = string.Concat("Nome Test TDD", DateTime.Now.ToString()),
                    Valor = 20,
                    UserId = "c5fe6ba9-8f82-4881-84c5-c3b6a8732edb"
                };
                await _IServiceProduct.AddProduct(produto);

                Assert.IsFalse(produto.Notitycoes.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task AddProductComValidacaoCampoObrigatorio()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                IServiceProduct _IServiceProduct = new ServiceProduct(_IProduct);
                var produto = new Produto
                {

                };
                await _IServiceProduct.AddProduct(produto);

                Assert.IsTrue(produto.Notitycoes.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task ListarProdutosUsuario()
        {

            try
            {
                IProduct _IProduct = new RepositoryProduct();

                var listaProdutos = await _IProduct.ListarProdutosUsuario("c5fe6ba9-8f82-4881-84c5-c3b6a8732edb");

                Assert.IsTrue(listaProdutos.Any());
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task GetEntityById()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                var listaProdutos = await _IProduct.ListarProdutosUsuario("c5fe6ba9-8f82-4881-84c5-c3b6a8732edb");
                var produto = await _IProduct.GetEntityById(listaProdutos.LastOrDefault().Id);

                Assert.IsTrue(produto != null);
            }
            catch (Exception)
            {

                Assert.Fail();
            }
        }

        [TestMethod]
        public async Task Delete()
        {
            try
            {
                IProduct _IProduct = new RepositoryProduct();
                var listaProdutos = await _IProduct.ListarProdutosUsuario("c5fe6ba9-8f82-4881-84c5-c3b6a8732edb");
                var ultimoProduto = listaProdutos.LastOrDefault();
                await _IProduct.Delete(ultimoProduto);
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }


    }
}
