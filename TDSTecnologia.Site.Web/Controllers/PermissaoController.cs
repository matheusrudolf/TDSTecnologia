using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSTecnologia.Site.Infrastructure.Services;

namespace TDSTecnologia.Site.Web.Controllers
{
    public class PermissaoController : Controller
    {
        private readonly PermissaoService _permissaoService;

        public PermissaoController(PermissaoService permissaoService)
        {
            _permissaoService = permissaoService;
        }

        public IActionResult Index()
        {
            return View("Index");
        }
    }
}
