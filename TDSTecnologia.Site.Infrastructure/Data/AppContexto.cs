using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Dominio;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Map;

namespace TDSTecnologia.Site.Infrastructure.Data
{
    public class AppContexto : IdentityDbContext<Usuario, Permissao, string>
    {
        public AppContexto(DbContextOptions<AppContexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Curso> CursoDao { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapConfiguration());
        }
    }
}
