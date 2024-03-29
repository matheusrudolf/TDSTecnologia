﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;
using TDSTecnologia.Site.Infrastructure.Services;

namespace TDSTecnologia.Site.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<CursoRepository, CursoRepository>();
            services.AddMvc();
            services.AddEntityFrameworkNpgsql()
         .AddDbContext<AppContexto>(options => options.UseNpgsql(Configuration.GetConnectionString("AppConnection")));
            services.AddScoped<CursoService, CursoService>();
            services.AddScoped<PermissaoService, PermissaoService>();
            services.AddScoped<UsuarioService, UsuarioService>();
            services.AddIdentity<Usuario, Permissao>()
                                        .AddDefaultUI(UIFramework.Bootstrap4)
                                        .AddEntityFrameworkStores<AppContexto>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
        }

    }
}
