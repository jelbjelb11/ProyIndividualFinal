using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class ColeccionTiposRepository : IColeccionTiposRepository
    {
        public ColeccionTipo Create(ColeccionTipo coleccionTipo)
        {
            return ApplicationDbContext.applicationDbContext.ColeccionTipos.Add(coleccionTipo);
        }

        public ColeccionTipo Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.ColeccionTipos.Find(id);
        }

        public IQueryable<ColeccionTipo> Get()
        {
            IList<ColeccionTipo> lista = new List<ColeccionTipo>(ApplicationDbContext.applicationDbContext.ColeccionTipos);

            return lista.AsQueryable();
        }


        public void Put(ColeccionTipo coleccionTipo)
        {
            if (ApplicationDbContext.applicationDbContext.ColeccionTipos.Count(e => e.Id == coleccionTipo.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(coleccionTipo).State = EntityState.Modified;
        }

        public ColeccionTipo Delete(long id)
        {
            ColeccionTipo coleccionTipo = ApplicationDbContext.applicationDbContext.ColeccionTipos.Find(id);
            if (coleccionTipo == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.ColeccionTipos.Remove(coleccionTipo);
            return coleccionTipo;
        }
    }
}