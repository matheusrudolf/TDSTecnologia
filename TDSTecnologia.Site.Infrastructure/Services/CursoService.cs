﻿using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;
using X.PagedList;

namespace TDSTecnologia.Site.Infrastructure.Services
{
    public class CursoService : BasicService
    {
        private readonly CursoRepository _cursoRepository;

        public CursoService(AppContexto context) : base(context)
        {
            _cursoRepository = new CursoRepository(context);
        }

        public List<Curso> ListarTodos()
        {
            return _cursoRepository.ListarTodos();
        }

        public void Salvar(Curso curso)
        {
            _context.Add(curso);
            SaveChangesApp();
        }

        public Curso PesquisarPorId(int? id)
        {
            return _cursoRepository.PesquisarPorId(id);
        }

        public void Atualizar(Curso curso)
        {
            _cursoRepository.Atualizar(curso);
            SaveChangesApp();
        }

        public void Excluir(int? id)
        {
            var curso = PesquisarPorId(id);
            _cursoRepository.Excluir(curso);
            SaveChangesApp();
        }

        public List<Curso> PesquisarPorNomeDescricao(string texto)
        {
            List<Curso> cursos = _cursoRepository.PesquisarPorNomeDescricao(texto);

            return cursos;
        }

        public IPagedList<Curso> ListarComPaginacao(int? pagina)
        {
            return _cursoRepository.ListarComPaginacao(pagina);
        }
    }
}
