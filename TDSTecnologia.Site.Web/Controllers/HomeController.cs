using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Core.Utilitarios;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;
using TDSTecnologia.Site.Infrastructure.Services;
using TDSTecnologia.Site.Web.ViewModels;
using X.PagedList;

namespace TDSTecnologia.Site.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppContexto _context;

        public HomeController(CursoService cursoService)
        {
            _cursoService = cursoService;
        }

        public IActionResult Index(int? pagina)
        {
            IPagedList<Curso> cursos = _cursoService.ListarComPaginacao(pagina);
            var viewModel = new CursoViewModel
            {
                CursosComPaginacao = cursos
            };

            return View(cursos);
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Novo([Bind("Id,Nome,Descricao,QuantidadeAula,DataInicio,Turno,Modalidade,Nivel,Vagas")] Curso curso, IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {
                curso.Banner = UtilImagem.ConverterParaByte(arquivo);
                _cursoService.Salvar(curso);
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoService.PesquisarPorId(id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        public IActionResult Alterar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoService.PesquisarPorId(id);

            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Alterar(int id, [Bind("Id,Nome,Descricao,QuatidadeAula,DataInicio,Turno,Modalidade,Nivel,Vagas")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _cursoService.Atualizar(curso);
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = _cursoService.PesquisarPorId(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmarExclusao(int id)
        {
            _cursoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }

        private readonly CursoRepository _cursoRepository;

        private readonly CursoService _cursoService;

        public IActionResult PesquisarCurso(CursoViewModel pesquisa)
        {
            if (pesquisa.Texto != null && !String.IsNullOrEmpty(pesquisa.Texto))
            {
                List<Curso> cursos = _cursoService.PesquisarPorNomeDescricao(pesquisa.Texto);
                var ViewModel = new CursoViewModel
                {
                    Cursos = cursos
                };
                return View("Index", ViewModel);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
