using Domain.Interfaces.InterfaceLogSistema;
using Entities.Entities;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryLogSistema : RepositoryGenerics<LogSistema>, ILogSistema
    {
    }
}
