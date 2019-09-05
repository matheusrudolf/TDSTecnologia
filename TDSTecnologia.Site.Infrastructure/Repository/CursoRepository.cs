using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;

namespace TDSTecnologia.Site.Infrastructure.Repository
{
    public class CursoRepository : BasicRepository
    {
        public CursoRepository(AppContexto context) : base(context)
        {
        }

        public List<Curso> ListarTodos()
        {

            return _context.CursoDao.ToList();
        }

        public Curso PesquisarPorId(int? id)
        {
            return _context.CursoDao.Find(id);
        }

        public void Salvar(Curso curso)
        {
            _context.Add(curso);
        }

    }
}
