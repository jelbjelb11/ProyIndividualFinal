using formulario.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace formulario.Repository
{
    public class DistribuidorEmpresasRepository : IDistribuidorEmpresasRepository
    {
        public DistribuidorEmpresa Create(DistribuidorEmpresa distribuidorEmpresa)
        {
            return ApplicationDbContext.applicationDbContext.DistribuidorEmpresas.Add(distribuidorEmpresa);
        }

        public DistribuidorEmpresa Get(long id)
        {
            return ApplicationDbContext.applicationDbContext.DistribuidorEmpresas.Find(id);
        }

        public IQueryable<DistribuidorEmpresa> Get()
        {
            IList<DistribuidorEmpresa> lista = new List<DistribuidorEmpresa>(ApplicationDbContext.applicationDbContext.DistribuidorEmpresas);

            return lista.AsQueryable();
        }


        public void Put(DistribuidorEmpresa distribuidorEmpresa)
        {
            if (ApplicationDbContext.applicationDbContext.DistribuidorEmpresas.Count(e => e.Id == distribuidorEmpresa.Id) == 0)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }
            ApplicationDbContext.applicationDbContext.Entry(distribuidorEmpresa).State = EntityState.Modified;
        }

        public DistribuidorEmpresa Delete(long id)
        {
            DistribuidorEmpresa distribuidorEmpresa = ApplicationDbContext.applicationDbContext.DistribuidorEmpresas.Find(id);
            if (distribuidorEmpresa == null)
            {
                throw new NoEncontradoException("No he encontrado la entidad");
            }

            ApplicationDbContext.applicationDbContext.DistribuidorEmpresas.Remove(distribuidorEmpresa);
            return distribuidorEmpresa;
        }
    }
}