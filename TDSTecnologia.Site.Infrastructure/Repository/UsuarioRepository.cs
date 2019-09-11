using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;

namespace TDSTecnologia.Site.Infrastructure.Repository
{
    public class UsuarioRepository : BasicRepository
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public UsuarioRepository(AppContexto context, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager) : base(context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
    }
}
