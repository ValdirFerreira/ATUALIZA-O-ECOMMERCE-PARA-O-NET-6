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
    public class ServiceMontaMenu : IServiceMontaMenu
    {
        private readonly IUsuario _IUsuario;
        public ServiceMontaMenu(IUsuario IUsuario)
        {
            _IUsuario = IUsuario;
        }

        public async Task<List<MenuSite>> MontaMenuPorPerfil(string userID)
        {
            var retorno = new List<MenuSite>();
            retorno.Add(new MenuSite { Controller = "Home", Action = "Index", Descricao = "Loja Virtual" });

            if (!string.IsNullOrWhiteSpace(userID))
            {
                // QUANDO USUÁRIO LOGADO USUÁRIO LOGADO 
                retorno.Add(new MenuSite { Controller = "Produtos", Action = "Index", Descricao = "Meus Produtos" });
                retorno.Add(new MenuSite { Controller = "CompraUsuario", Action = "MinhasCompras", Descricao = "Minhas Compras" });
                retorno.Add(new MenuSite { Controller = "Produtos", Action = "DashboardVendas", Descricao = "Minhas Vendas" });

                var usuario = await _IUsuario.ObterUsuarioPeloID(userID);
                if (usuario != null && usuario.Tipo != null)
                {
                    switch ((TipoUsuario)usuario.Tipo)
                    {
                        case TipoUsuario.Administrador:
                            retorno.Add(new MenuSite { Controller = "LogSistemas", Action = "Index", Descricao = "Logs" });
                            retorno.Add(new MenuSite { Controller = "Usuarios", Action = "ListarUsuarios", Descricao = "Usuários" });
                            break;
                        case TipoUsuario.Comum:
                            break;
                        default:
                            break;
                    }
                }

                retorno.Add(new MenuSite { Controller = "Produtos", Action = "ListarProdutosCarrinhoUsuario", Descricao = "", IdCampo = "qtdCarrinho", UrlImagem = "../img/carrinho.png" });

            }

            return retorno;
        }
    }
}
