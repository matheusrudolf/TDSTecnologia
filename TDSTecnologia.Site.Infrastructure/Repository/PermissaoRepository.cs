﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;

namespace TDSTecnologia.Site.Infrastructure.Repository
{
    public class PermissaoRepository : BasicRepository
    {
        private readonly RoleManager<Permissao> _roleManager;

        public PermissaoRepository(AppContexto contexto, RoleManager<Permissao> roleManager) : base(contexto)
        {
            _roleManager = roleManager;
        }

        public List<Permissao> ListarTodos()
        {
            return _context.Permissoes.ToList();
        }
    }
}
