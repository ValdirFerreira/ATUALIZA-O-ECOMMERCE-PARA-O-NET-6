using Domain.Interfaces.InterfaceCompra;
using Entities.Entities;
using Entities.Entities.Enums;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryCompra : RepositoryGenerics<Compra>, ICompra
    {

        private readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositoryCompra()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }


        public async Task<Compra> CompraPorEstado(string userId, EnumEstadoCompra estado)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Compra.FirstOrDefaultAsync(c => c.Estado == estado && c.UserId == userId);
            }
        }
    }
}
