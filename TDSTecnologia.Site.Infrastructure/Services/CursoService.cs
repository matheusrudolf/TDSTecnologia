using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;

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
    }
}
