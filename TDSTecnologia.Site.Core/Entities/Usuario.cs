using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace TDSTecnologia.Site.Core.Entities
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }

        public DbSet Usuarios { get; set; }
    }
}
