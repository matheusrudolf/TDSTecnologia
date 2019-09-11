﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;

namespace TDSTecnologia.Site.Infrastructure.Services
{
    public class UsuarioService : BasicService
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(AppContexto context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager) : base(context)
        {
            _usuarioRepository = new UsuarioRepository(context, userManager, signInManager);
        }
    }
}
