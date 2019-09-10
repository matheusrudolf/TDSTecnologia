using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;

namespace TDSTecnologia.Site.Infrastructure.Services
{
    public class PermissaoService : BasicService
    {
        private readonly PermissaoRepository _permissaoRepository;

        public PermissaoService(AppContexto contexto, RoleManager<Permissao> roleManager) : base(contexto)
        {
            _permissaoRepository = new PermissaoRepository(contexto, roleManager);
        }
    }
}
