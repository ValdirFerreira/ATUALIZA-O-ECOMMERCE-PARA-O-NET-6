using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceCompra;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppCompra : InterfaceCompraApp
    {

        private readonly ICompra _ICompra;
        public AppCompra(ICompra ICompra)
        {
            _ICompra = ICompra;
        }

        public async Task Add(Compra Objeto)
        {
            await _ICompra.Add(Objeto);
        }

        public async Task Delete(Compra Objeto)
        {
            await _ICompra.Delete(Objeto);
        }

        public async Task<Compra> GetEntityById(int Id)
        {
            return await _ICompra.GetEntityById(Id);
        }

        public async Task<List<Compra>> List()
        {
            return await _ICompra.List();
        }

        public async Task Update(Compra Objeto)
        {
            await _ICompra.Update(Objeto);
        }
    }
}
