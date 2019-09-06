using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;
using TDSTecnologia.Site.Infrastructure.Services;

namespace TDSTecnologia.Site.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppContexto _context;

        public HomeController(AppContexto context, CursoRepository cursoRepository)
        {
            _context = context;
            _cursoRepository = cursoRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Curso> cursos = await _cursoRepository.ListarTodos();

            return View(cursos);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo([Bind("Id,Nome,Descricao,QuantidadeAula,DataInicio,Turno")] Curso curso, IFormFile arquivo)
        {
            
            if (ModelState.IsValid)
            {
                if (arquivo != null && arquivo.ContentType.ToLower().StartsWith("image/"))
                {
                    MemoryStream ms = new MemoryStream();
                    await arquivo.OpenReadStream().CopyToAsync(ms);
                    curso.Banner = ms.ToArray();
                }
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);

        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.CursoDao.FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        private readonly CursoRepository _cursoRepository;

        private readonly CursoService _cursoService;

    }
}
